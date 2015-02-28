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
    internal class DmtxRay2
    {
        #region Fields
        double _tMin;
        double _tMax;
        DmtxVector2 _p;
        DmtxVector2 _v;
        #endregion

        #region Constructors
        internal DmtxRay2()
        {
            // pass
        }
        #endregion

        #region Properties
        internal DmtxVector2 P
        {
            get
            {
                if (_p == null)
                {
                    _p = new DmtxVector2();
                }
                return _p;
            }
            set
            {
                _p = value;
            }
        }

        internal DmtxVector2 V
        {
            get
            {
                if (_v == null)
                {
                    _v = new DmtxVector2();
                }
                return _v;
            }
            set
            {
                _v = value;
            }
        }


        internal double TMin
        {
            get
            {
                return _tMin;
            }
            set
            {
                _tMin = value;
            } 
        }

        internal double TMax
        {
            get
            {
                return _tMax;
            }
            set
            {
                _tMax = value;
            }
        }
        #endregion
    }
}
