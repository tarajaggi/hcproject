using System;
using ClassLibraryDAL;
using ClassLibraryMODEL;

namespace ClassLibraryBLL
{
    public class HcBLL
    {
        HcDAL objDAL = new HcDAL();
        /*public void GetMaxId(string prefix)
        {
            objDAL.GetMaxId(prefix);
        }
        */
        public void UserRegister(HcModel objectModelReg)
        {
            objDAL.UserRegister(objectModelReg);
        }






    
}
