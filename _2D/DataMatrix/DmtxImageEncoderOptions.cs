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
using System.Drawing;

namespace Barcode._2D
{
    class DmtxImageEncoderOptions
    {
        #region Fields
        int _marginSize = 0;
        int _moduleSize = 0;
        DmtxScheme _scheme = DmtxScheme.DmtxSchemeAscii;
        DmtxSymbolSize _sizeIdx = DmtxSymbolSize.DmtxSymbolSquareAuto;
        Color _color = Color.Black;
        Color _bgColor = Color.White;
        #endregion

        #region Properties

        public int MarginSize
        {
            get { return _marginSize; }
            set { _marginSize = value; }
        }

        public int ModuleSize
        {
            get { return _moduleSize; }
            set { _moduleSize = value; }
        }

        public DmtxScheme Scheme
        {
            get { return _scheme; }
            set { _scheme = value; }
        }

        public DmtxSymbolSize SizeIdx
        {
            get { return _sizeIdx; }
            set { _sizeIdx = value; }
        }

        public Color ForeColor
        {
            get { return _color; }
            set
            {
                _color = value;
            }
        }

        public Color BackColor
        {
            get { return _bgColor; }
            set { _bgColor = value; }
        }

        #endregion
    }
}
