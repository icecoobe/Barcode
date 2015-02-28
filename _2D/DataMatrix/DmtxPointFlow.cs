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
    internal class DmtxPointFlow
    {
        #region Fields
        int _plane;
        int _arrive;
        int _depart;
        int _mag;
        DmtxPixelLoc _loc;
        #endregion

        #region Properties
        internal int Plane
        {
            get
            {
                return _plane;
            }
            set
            {
                _plane = value;
            }
        }

        internal int Arrive
        {
            get
            {
                return _arrive;
            }
            set
            {
                _arrive = value;
            }
        }

        internal int Depart
        {
            get
            {
                return _depart;
            }
            set
            {
                _depart = value;
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

        internal DmtxPixelLoc Loc
        {
            get
            {
                return _loc;
            }
            set
            {
                _loc = value;
            }
        }
        #endregion
    }
}
