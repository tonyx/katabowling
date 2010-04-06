using System;
using System.Collections.Generic;

namespace ocpBowling
{
    public class GeometricConstraintChecker:IConstraintChecker
    {
        private ConstraintAndDescription _constToAdd;
        public void CheckConstraint(Frame frame, int index, Dictionary<int, ConstraintAndDescription> indexConstraintForFrame)
        {
            AddConstrains(index, frame, indexConstraintForFrame);        

            ConstraintAndDescription constrintAndDescription;
            if (indexConstraintForFrame.TryGetValue(index, out constrintAndDescription))
            {
                if (!constrintAndDescription.Matches(frame))
                {
                    throw new FormatException("violated constraint " + constrintAndDescription + " in frame " + frame.ToString());
                }
            }
            else
                throw new FormatException("rule error: there is no constraint for frame index " + index);
        
        }

        private void AddConstrains(int index, Frame frame, Dictionary<int, ConstraintAndDescription> indexConstraintForFrame)
        {
            if (index==0&&frame.Rolls.Count>1)
            {
                for (int i = 1; i < frame.Rolls.Count-1;i++)
                {
                    indexConstraintForFrame.Add(i, _constToAdd);
                }
            }
        }

        public GeometricConstraintChecker(ConstraintAndDescription constToAdd)
        {
            this._constToAdd = constToAdd;            
        }


    }
}