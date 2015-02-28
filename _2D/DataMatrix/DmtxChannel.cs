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

namespace Barcode._2D
{
    internal class DmtxChannel
    {
        DmtxScheme _encScheme;     /* current encodation scheme */
        DmtxChannelStatus _invalid;
        int _inputIndex;      /* pointer to current input character */
        int _encodedLength; /* encoded length (units of 2/3 bits) */
        int _currentLength; /* current length (units of 2/3 bits) */
        int _firstCodeWord; /* */
        byte[] _encodedWords;
        byte[] _input;

        internal byte[] Input
        {
            get
            {
                return _input;
            }
            set
            {
                _input = value;
            }
        }

        internal DmtxScheme EncScheme
        {
            get { return _encScheme; }
            set { _encScheme = value; }
        }

        internal DmtxChannelStatus Invalid
        {
            get { return _invalid; }
            set { _invalid = value; }
        }

        internal int InputIndex
        {
            get { return _inputIndex; }
            set { _inputIndex = value; }
        }

        internal int EncodedLength
        {
            get { return _encodedLength; }
            set { _encodedLength = value; }
        }

        internal int CurrentLength
        {
            get { return _currentLength; }
            set { _currentLength = value; }
        }

        internal int FirstCodeWord
        {
            get { return _firstCodeWord; }
            set { _firstCodeWord = value; }
        }


        internal byte[] EncodedWords
        {
            get
            {
                if (_encodedWords == null)
                {
                    _encodedWords = new byte[1558];
                }
                return _encodedWords;
            }
        }
    }

    internal class DmtxChannelGroup
    {
        DmtxChannel[] _channels;

        internal DmtxChannel[] Channels
        {
            get
            {
                if (_channels == null)
                {
                    _channels = new DmtxChannel[6];
                    for (int i = 0; i < 6; i++)
                    {
                        _channels[i] = new DmtxChannel();
                    }
                }
                return _channels;
            }
        }
    }
}
