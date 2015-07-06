using System;

namespace Arquivador.DataClass.Structure
{
    [Serializable]
    public class ExclusionStructure : PathTableStructure
    {
        #region "Constructors"
        public ExclusionStructure()
            : base("TB_EXCLUSION", "IdExclusion", "Path")
        { }
        #endregion
    }
}
