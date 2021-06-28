using System;
using System.Collections.Generic;
using System.Text;

namespace SSDCPortal.Shared.Dto
{
    public interface IMementoDto
    {
        void SaveState();
        void RestoreState();
        void ClearState();
    }
}
