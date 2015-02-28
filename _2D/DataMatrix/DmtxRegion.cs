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
    internal class DmtxRegion
    {
        #region Fields
        /* Trail blazing values */
        int _jumpToPos;
        int _jumpToNeg;
        int _stepsTotal;
        DmtxPixelLoc _finalPos;
        DmtxPixelLoc _finalNeg;
        DmtxPixelLoc _boundMin;
        DmtxPixelLoc _boundMax;
        DmtxPointFlow _flowBegin;

        /* Orientation values */
        int _polarity;
        int _stepR;
        int _stepT;
        DmtxPixelLoc _locR;
        DmtxPixelLoc _locT;

        /* Region fitting values */
        int _leftKnown;
        int _leftAngle;

        DmtxPixelLoc _leftLoc;
        DmtxBestLine _leftLine;
        int _bottomKnown;
        int _bottomAngle;
        DmtxPixelLoc _bottomLoc;
        DmtxBestLine _bottomLine;
        int _topKnown;      /* known == 1; unknown == 0 */
        int _topAngle;      /* hough angle of top edge */
        DmtxPixelLoc _topLoc;        /* known (arbitrary) location on top edge */
        int _rightKnown;    /* known == 1; unknown == 0 */
        int _rightAngle;    /* hough angle of right edge */
        DmtxPixelLoc _rightLoc;      /* known (arbitrary) location on right edge */

        /* Region calibration values */
        int _onColor;
        int _offColor;
        DmtxSymbolSize _sizeIdx;       /* Index of arrays that store Data Matrix constants */
        int _symbolRows;    /* Number of total rows in symbol including alignment patterns */
        int _symbolCols;    /* Number of total columns in symbol including alignment patterns */
        int _mappingRows;   /* Number of data rows in symbol */
        int _mappingCols;   /* Number of data columns in symbol */

        /* Transform values */
        DmtxMatrix3 _raw2fit;       /* 3x3 transformation from raw image to fitted barcode grid */
        DmtxMatrix3 _fit2raw;       /* 3x3 transformation from fitted barcode grid to raw image */
        #endregion

        #region Constructors

        internal DmtxRegion()
        {
        }

        internal DmtxRegion(DmtxRegion src)
        {
            this._bottomAngle = src._bottomAngle;
            this._bottomKnown = src._bottomKnown;
            this._bottomLine = src._bottomLine;
            this._bottomLoc = src._bottomLoc;
            this._boundMax = src._boundMax;
            this._boundMin = src._boundMin;
            this._finalNeg = src._finalNeg;
            this._finalPos = src._finalPos;
            this._fit2raw = new DmtxMatrix3(src._fit2raw);
            this._flowBegin = src._flowBegin;
            this._jumpToNeg = src._jumpToNeg;
            this._jumpToPos = src._jumpToPos;
            this._leftAngle = src._leftAngle;
            this._leftKnown = src._leftKnown;
            this._leftLine = src._leftLine;
            this._leftLoc = src._leftLoc;
            this._locR = src._locR;
            this._locT = src._locT;
            this._mappingCols = src._mappingCols;
            this._mappingRows = src._mappingRows;
            this._offColor = src._offColor;
            this._onColor = src._onColor;
            this._polarity = src._polarity;
            this._raw2fit = new DmtxMatrix3(src._raw2fit);
            this._rightAngle = src._rightAngle;
            this._rightKnown = src._rightKnown;
            this._rightLoc = src._rightLoc;
            this._sizeIdx = src._sizeIdx;
            this._stepR = src._stepR;
            this._stepsTotal = src._stepsTotal;
            this._stepT = src._stepT;
            this._symbolCols = src._symbolCols;
            this._symbolRows = src._symbolRows;
            this._topAngle = src._topAngle;
            this._topKnown = src._topKnown;
            this._topLoc = src._topLoc;
        }
        #endregion

        #region Methods
        #endregion

        #region Properties
        internal int JumpToPos
        {
            get { return _jumpToPos; }
            set { _jumpToPos = value; }
        }

        internal int JumpToNeg
        {
            get { return _jumpToNeg; }
            set { _jumpToNeg = value; }
        }

        internal int StepsTotal
        {
            get { return _stepsTotal; }
            set { _stepsTotal = value; }
        }

        internal DmtxPixelLoc FinalPos
        {
            get { return _finalPos; }
            set { _finalPos = value; }
        }

        internal DmtxPixelLoc FinalNeg
        {
            get { return _finalNeg; }
            set { _finalNeg = value; }
        }

        internal DmtxPixelLoc BoundMin
        {
            get { return _boundMin; }
            set { _boundMin = value; }
        }

        internal DmtxPixelLoc BoundMax
        {
            get { return _boundMax; }
            set { _boundMax = value; }
        }

        internal DmtxPointFlow FlowBegin
        {
            get { return _flowBegin; }
            set { _flowBegin = value; }
        }

        internal int Polarity
        {
            get { return _polarity; }
            set { _polarity = value; }
        }

        internal int StepR
        {
            get { return _stepR; }
            set { _stepR = value; }
        }

        internal int StepT
        {
            get { return _stepT; }
            set { _stepT = value; }
        }

        internal DmtxPixelLoc LocR
        {
            get { return _locR; }
            set { _locR = value; }
        }

        internal DmtxPixelLoc LocT
        {
            get { return _locT; }
            set { _locT = value; }
        }

        internal int LeftKnown
        {
            get { return _leftKnown; }
            set { _leftKnown = value; }
        }

        internal int LeftAngle
        {
            get { return _leftAngle; }
            set { _leftAngle = value; }
        }

        internal DmtxPixelLoc LeftLoc
        {
            get { return _leftLoc; }
            set { _leftLoc = value; }
        }

        internal DmtxBestLine LeftLine
        {
            get { return _leftLine; }
            set { _leftLine = value; }
        }

        internal int BottomKnown
        {
            get { return _bottomKnown; }
            set { _bottomKnown = value; }
        }

        internal int BottomAngle
        {
            get { return _bottomAngle; }
            set { _bottomAngle = value; }
        }

        internal DmtxPixelLoc BottomLoc
        {
            get { return _bottomLoc; }
            set { _bottomLoc = value; }
        }

        internal DmtxBestLine BottomLine
        {
            get { return _bottomLine; }
            set { _bottomLine = value; }
        }

        internal int TopKnown
        {
            get { return _topKnown; }
            set { _topKnown = value; }
        }

        internal int TopAngle
        {
            get { return _topAngle; }
            set { _topAngle = value; }
        }

        internal DmtxPixelLoc TopLoc
        {
            get { return _topLoc; }
            set { _topLoc = value; }
        }

        internal int RightKnown
        {
            get { return _rightKnown; }
            set { _rightKnown = value; }
        }

        internal int RightAngle
        {
            get { return _rightAngle; }
            set { _rightAngle = value; }
        }

        internal DmtxPixelLoc RightLoc
        {
            get { return _rightLoc; }
            set { _rightLoc = value; }
        }

        internal int OnColor
        {
            get { return _onColor; }
            set { _onColor = value; }
        }

        internal int OffColor
        {
            get { return _offColor; }
            set { _offColor = value; }
        }

        internal DmtxSymbolSize SizeIdx
        {
            get { return _sizeIdx; }
            set { _sizeIdx = value; }
        }

        internal int SymbolRows
        {
            get { return _symbolRows; }
            set { _symbolRows = value; }
        }

        internal int SymbolCols
        {
            get { return _symbolCols; }
            set { _symbolCols = value; }
        }

        internal int MappingRows
        {
            get { return _mappingRows; }
            set { _mappingRows = value; }
        }

        internal int MappingCols
        {
            get { return _mappingCols; }
            set { _mappingCols = value; }
        }

        internal DmtxMatrix3 Raw2fit
        {
            get { return _raw2fit; }
            set { _raw2fit = value; }
        }

        internal DmtxMatrix3 Fit2raw
        {
            get { return _fit2raw; }
            set { _fit2raw = value; }
        }
        #endregion
    }
}
