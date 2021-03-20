using System;

namespace Netactica.Models.Tools
{
    public static class ToolsResponseModel
    {
        public static T GetModel<T>(this ResponseModel response)
        {
            try
            {
                switch (response.CodeValue)
                {
                    case (int)EnumSuccesCode.Fail:
                        return default(T);

                    case (int)EnumSuccesCode.FailBusiness:
                        return default(T);

                    case (int)EnumSuccesCode.NotFound:
                        return default(T);

                    case (int)EnumSuccesCode.Succes:
                        if (response.Data is T)
                            return (T)response.Data;
                        else
                            return default(T);
                }

                return default(T);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}