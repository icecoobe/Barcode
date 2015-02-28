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
    internal struct DmtxBestLine
    {
        int _angle;
        int _hOffset;
        int _mag;
        int _stepBeg;
        int _stepPos;
        int _stepNeg;
        int _distSq;
        double _devn;
        DmtxPixelLoc _locBeg;
        DmtxPixelLoc _locPos;
        DmtxPixelLoc _locNeg;

        internal int Angle
        {
            get
            {
                return _angle;
            }
            set
            {
                _angle = value;
            }
        }

        internal int HOffset
        {
            get
            {
                return _hOffset;
            }
            set
            {
                _hOffset = value;
            }
        }

        internal int Mag
        {
            get
            {
                return _mag;
            }
            set
            {
                _mag = value;
            }
        }

        internal int StepBeg
        {
            get
            {
                return _stepBeg;
            }
            set
            {
                _stepBeg = value;
            }
        }

        internal int StepPos
        {
            get
            {
                return _stepPos;
            }
            set
            {
                _stepPos = value;
            }
        }

        internal int StepNeg
        {
            get
            {
                return _stepNeg;
            }
            set
            {
                _stepNeg = value;
            }
        }

        internal int DistSq
        {
            get
            {
                return _distSq;
            }
            set
            {
                _distSq = value;
            }
        }

        internal double Devn
        {
            get
            {
                return _devn;
            }
            set
            {
                _devn = value;
            }
        }

        internal DmtxPixelLoc LocBeg
        {
            get
            {
                return _locBeg;
            }
            set
            {
                _locBeg = value;
            }
        }

        internal DmtxPixelLoc LocPos
        {
            get
            {
                return _locPos;
            }
            set
            {
                _locPos = value;
            }
        }

        internal DmtxPixelLoc LocNeg
        {
            get
            {
                return _locNeg;
            }
            set
            {
                _locNeg = value;
            }
        }
    }
}
