/*
DataMatrix.Net

DataMatrix.Net - .net library for decoding DataMatrix codes.
Copyright (C) 2009/2010 Michael Faschinger

This library is free software; you can redistribute it and/or
modify it under the terms of the GNU General Public
License as published by the Free Software Foundation; either
version 3.0 of the License, or (at your option) any later version.
You can also redistribute and/or modify it under the terms of the
GNU Lesser General Public License as published by the Free Software
Foundation; either version 3.0 of the License or (at your option)
any later version.

This library is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
General Public License or the GNU Lesser General Public License 
for more details.

You should have received a copy of the GNU General Public
License and the GNU Lesser General Public License along with this 
library; if not, write to the Free Software Foundation, Inc., 
51 Franklin Street, Fifth Floor, Boston, MA  02110-1301  USA

Contact: Michael Faschinger - michfasch@gmx.at
 
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Barcode._2D
{
    internal class DmtxImage
    {
        #region Fields
        int _width;
        int _height;
        DmtxPackOrder _pixelPacking;
        int _bitsPerPixel;
        int _bytesPerPixel;
        int _rowPadBytes;
        int _rowSizeBytes;
        DmtxFlip _imageFlip;
        int _channelCount;
        int[] _channelStart;
        int[] _bitsPerChannel;
        byte[] _pxl;
        #endregion

        #region Constructor
        internal DmtxImage(byte[] pxl, int width, int height, DmtxPackOrder pack)
        {
            _bitsPerChannel = new int[4];
            _channelStart = new int[4];
            if (pxl == null || width < 1 || height < 1)
            {
                throw new ArgumentException("Cannot create image of size null");
            }

            this._pxl = pxl;
            this._width = width;
            this._height = height;
            this._pixelPacking = pack;
            this._bitsPerPixel = DmtxCommon.GetBitsPerPixel(pack);
            this._bytesPerPixel = this._bitsPerPixel / 8;
            this._rowPadBytes = 0;
            this._rowSizeBytes = this._width * this._bytesPerPixel + this._rowPadBytes;
            this._imageFlip = DmtxFlip.DmtxFlipNone;

            /* Leave channelStart[] and bitsPerChannel[] with zeros from calloc */
            this._channelCount = 0;

            switch (pack)
            {
                case DmtxPackOrder.DmtxPackCustom:
                    break;
                case DmtxPackOrder.DmtxPack1bppK:
                    throw new ArgumentException("Cannot create image: not supported pack order!");
                case DmtxPackOrder.DmtxPack8bppK:
                    SetChannel(0, 8);
                    break;
                case DmtxPackOrder.DmtxPack16bppRGB:
                case DmtxPackOrder.DmtxPack16bppBGR:
                case DmtxPackOrder.DmtxPack16bppYCbCr:
                    SetChannel(0, 5);
                    SetChannel(5, 5);
                    SetChannel(10, 5);
                    break;
                case DmtxPackOrder.DmtxPack24bppRGB:
                case DmtxPackOrder.DmtxPack24bppBGR:
                case DmtxPackOrder.DmtxPack24bppYCbCr:
                case DmtxPackOrder.DmtxPack32bppRGBX:
                case DmtxPackOrder.DmtxPack32bppBGRX:
                    SetChannel(0, 8);
                    SetChannel(8, 8);
                    SetChannel(16, 8);
                    break;
                case DmtxPackOrder.DmtxPack16bppRGBX:
                case DmtxPackOrder.DmtxPack16bppBGRX:
                    SetChannel(0, 5);
                    SetChannel(5, 5);
                    SetChannel(10, 5);
                    break;
                case DmtxPackOrder.DmtxPack16bppXRGB:
                case DmtxPackOrder.DmtxPack16bppXBGR:
                    SetChannel(1, 5);
                    SetChannel(6, 5);
                    SetChannel(11, 5);
                    break;
                case DmtxPackOrder.DmtxPack32bppXRGB:
                case DmtxPackOrder.DmtxPack32bppXBGR:
                    SetChannel(8, 8);
                    SetChannel(16, 8);
                    SetChannel(24, 8);
                    break;
                case DmtxPackOrder.DmtxPack32bppCMYK:
                    SetChannel(0, 8);
                    SetChannel(8, 8);
                    SetChannel(16, 8);
                    SetChannel(24, 8);
                    break;
                default:
                    throw new ArgumentException("Cannot create image: Invalid Pack Order");
            }
        }
        #endregion

        #region Methods
        internal bool SetChannel(int channelStart, int bitsPerChannel)
        {
            if (this._channelCount >= 4) /* IMAGE_MAX_CHANNEL */
                return false;

            /* New channel extends beyond pixel data */

            this._bitsPerChannel[this._channelCount] = bitsPerChannel;
            this._channelStart[this._channelCount] = channelStart;
            (this._channelCount)++;

            return true;
        }

        internal int GetByteOffset(int x, int y)
        {
            if (this._imageFlip == DmtxFlip.DmtxFlipX)
            {
                throw new ArgumentException("DmtxFlipX is not an option!");
            }

            if (!ContainsInt(0, x, y))
                return DmtxConstants.DmtxUndefined;

            if (this._imageFlip == DmtxFlip.DmtxFlipY)
                return (y * this._rowSizeBytes + x * this._bytesPerPixel);

            return ((this._height - y - 1) * this._rowSizeBytes + x * this._bytesPerPixel);
        }

        internal bool GetPixelValue(int x, int y, int channel, ref int value)
        {
            if (channel >= this._channelCount)
            {
                throw new ArgumentException("Channel greater than channel count!");
            }

            int offset = GetByteOffset(x, y);
            if (offset == DmtxConstants.DmtxUndefined)
            {
                return false;
            }

            switch (this._bitsPerChannel[channel])
            {
                case 1:
                    break;
                case 5:
                    break;
                case 8:
                    if (this._channelStart[channel] % 8 != 0 || this._bitsPerPixel % 8 != 0)
                    {
                        throw new Exception("Error getting pixel value");
                    }
                    value = this._pxl[offset + channel];
                    break;
            }

            return true;
        }

        internal bool SetPixelValue(int x, int y, int channel, byte value)
        {
            if (channel >= this._channelCount)
            {
                throw new ArgumentException("Channel greater than channel count!");
            }

            int offset = GetByteOffset(x, y);
            if (offset == DmtxConstants.DmtxUndefined)
            {
                return false;
            }

            switch (this._bitsPerChannel[channel])
            {
                case 1:
                    break;
                case 5:
                    break;
                case 8:
                    if (this._channelStart[channel] % 8 != 0 || this._bitsPerPixel % 8 != 0)
                    {
                        throw new Exception("Error getting pixel value");
                    }
                    this._pxl[offset + channel] = value;
                    break;
            }

            return true;
        }

        internal bool ContainsInt(int margin, int x, int y)
        {
            if (x - margin >= 0 && x + margin < this._width &&
                  y - margin >= 0 && y + margin < this._height)
                return true;

            return false;
        }

        internal bool ContainsFloat(double x, double y)
        {
            if (x >= 0.0 && x < (double)this._width && y >= 0.0 && y < (double)this._height)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region Properties
        internal int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        internal int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        internal DmtxPackOrder PixelPacking
        {
            get { return _pixelPacking; }
            set { _pixelPacking = value; }
        }

        internal int BitsPerPixel
        {
            get { return _bitsPerPixel; }
            set { _bitsPerPixel = value; }
        }

        internal int BytesPerPixel
        {
            get { return _bytesPerPixel; }
            set { _bytesPerPixel = value; }
        }

        internal int RowPadBytes
        {
            get { return _rowPadBytes; }
            set
            {
                _rowPadBytes = value;
                this._rowSizeBytes = this._width * (this._bitsPerPixel / 8) + this._rowPadBytes;
            }
        }

        internal int RowSizeBytes
        {
            get { return _rowSizeBytes; }
            set { _rowSizeBytes = value; }
        }

        internal DmtxFlip ImageFlip
        {
            get { return _imageFlip; }
            set { _imageFlip = value; }
        }

        internal int ChannelCount
        {
            get { return _channelCount; }
            set { _channelCount = value; }
        }

        internal int[] ChannelStart
        {
            get { return _channelStart; }
            set { _channelStart = value; }
        }

        internal int[] BitsPerChannel
        {
            get { return _bitsPerChannel; }
            set { _bitsPerChannel = value; }
        }

        internal byte[] Pxl
        {
            get { return _pxl; }
            set { _pxl = value; }
        }
        #endregion
    }
}
