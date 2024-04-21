using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Extensions;
namespace Core.DataBase.ADOProvider.ShSqlCommand
{
    /// <summary>
    /// Câu lệnh thực hiện Save = Update Hoặc Insert
    /// </summary>
    class ShSaveCommand : ShCommand
    {
        public override void Build(ModelBase t, TSqlBuilder builder, params string[] fields)
        {
            // Buid câu lệnh Update
            var update = new ShUpdateCommand();
            update.Build(t, builder, fields);

            // Build câu lệnh Insert
            var insert = new ShInsertCommand();
            insert.Build(t, builder, fields);

            // Xem có trường tự tăng thì lấy ra số tự tăng
            var fn = builder.FieldPKs.FirstOrDefault(f => f != null && f.IsIdentity);

            // Tạo identity theo key tự tăng
            var @identity = fn != null ? "SELECT @{0} {0}".Frmat(fn.FieldName) : "SELECT 0";

            // Build câu lệnh Save, nếu như lệnh cập nhật không được thì thực hiện Insert
            Command = "{0} IF(@@ROWCOUNT = 0) {1} ELSE {2}".Frmat(update.Command, insert.Command, @identity);

            Parameter = update.Parameter; // Vì câu lệnh Update đầy đủ Parameter nhất
        }
    }
}
