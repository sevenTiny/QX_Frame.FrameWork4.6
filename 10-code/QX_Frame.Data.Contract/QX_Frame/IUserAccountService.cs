﻿using QX_Frame.Data.Entities.QX_Frame;

namespace QX_Frame.Data.Contract.QX_Frame
{
    public interface  IUserAccountService
    {
        bool Add(tb_UserAccount userAccount);
        bool Update(tb_UserAccount userAccount);
        bool Delete(tb_UserAccount userAccount);
    }
}
