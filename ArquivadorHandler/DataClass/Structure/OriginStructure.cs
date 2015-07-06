using System;

namespace Arquivador.DataClass.Structure
{
    [Serializable]
    public class OriginStructure : PathTableStructure
    {
        #region "Constructors"
        public OriginStructure()
            : base("TB_ORIGIN", "IdOrigin", "Path")
        { }
        #endregion
    }
}
