using Netactica.Models.Exceptions;
using System;

namespace Netactica.Models
{
    public class ResponseModel
    {
        public string Message { get; set; }

        public bool Success { get; set; }

        public int CodeValue { get; set; }

        public object Data { get; set; }

        public string InfoMessage { get; set; }

        public void SuccesCall(object data, string msg = "")
        {
            Message = msg;
            Success = true;
            Data = data;
            CodeValue = (int)EnumSuccesCode.Succes;
        }

        public void Fail(string msg = "")
        {
            Message = msg;
            Success = false;
            CodeValue = (int)EnumSuccesCode.Fail;
        }

        public void NotFound(string msg = "")
        {
            Message = msg;
            Success = false;
            CodeValue = (int)EnumSuccesCode.NotFound;
        }

        public void NotFound(Exception ex, string msg = "")
        {
            Message = ex.Message;
            InfoMessage = msg;
            Success = false;
            CodeValue = (int)EnumSuccesCode.NotFound;
        }

        public void Fail(Exception ex, string msg = "")
        {
            Message = ex.Message;
            InfoMessage = msg;
            Success = false;
            CodeValue = (int)EnumSuccesCode.Fail;
        }

        public void Fail(BusinessException ex, string msg = "")
        {
            Message = ex.Message;
            InfoMessage = msg;
            Success = false;
            CodeValue = (int)EnumSuccesCode.FailBusiness;
        }
    }

    public enum EnumSuccesCode
    {
        Succes = 1,
        Fail = -1,
        FailBusiness = -2,
        NotFound = -3
    }
}