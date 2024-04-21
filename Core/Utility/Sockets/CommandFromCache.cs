using System;
using System.Collections.Generic;
using System.Linq;
using Core.Extensions;

namespace Core.Utility.Sockets
{
    /// <summary>
    /// Cache các Command theo từng luồng
    /// Việc cache sẽ lưu lại ví dụ như: 
    /// CommandInfo từ lái xe về server lái xe thì gồm những Command nào
    /// CommandInfo từ điều hành về server lái xe thì gồm những Command nào v.v...
    /// Khi khởi tạo Connection, thì tùy theo connection này nhận nhiệm vụ xử lý CommandInfo từ khối nào gửi đến
    /// thì sẽ tạo tập các Command để đón nhận các CommandInfo và xử lý tương ứng
    /// </summary>
    public class CommandFromCache : DictionaryCacheBase<CommandFrom, List<Type>, CommandFromCache>
    {
        protected override List<Type> GetValueForDic(CommandFrom key)
        {
            var group =
                    typeof(CommandAttribute).Assembly.GetTypes() // Tìm tất cả các type Assembly Staxi.Servers
                    .Where(t => !t.IsAbstract)                   // Loại trừ các type là abstract ra. Vì abstract thì không khởi tạo constructor được
                    .Where(t => t.CompareType(typeof(Command)))  // Chỉ lấy các class là Command được đánh dấu CommandAttribute thôi. Các class không phải là Command thì loại
                    .Select(t => new { Type = t, CommandAttribute = t.GetAttribute<CommandAttribute>() }) // Select để lấy được cặp type Command và CommandAttribute
                    .Where(t => t.CommandAttribute != null)                                               // Loại từ các Command không được đánh dấu CommandAttribute
                    .GroupBy(t => t.CommandAttribute.CommandFrom).FirstOrDefault(g => g.Key == key);      // Phân nhóm từng luồng (từng CommandFrom) thì có tập lệnh gì và từ đó với CommandFrom key đầu vào thì suy ra tập lệnh cần trả ra
            return group == null ? new List<Type> { } : group.Select(gi => gi.Type).ToList();
        }
    }

    public static class CommandFromExtension
    {
        /// <summary>
        /// Phương thức hỗ trợ từ luồng hệ thống suy ra tập lệnh
        /// Các tập lệnh được lấy ra từ CommandFromCache
        /// </summary>
        /// <param name="commandFrom"></param>
        /// <returns></returns>
        public static List<Type> GetCommands(this CommandFrom commandFrom)
        {
            return CommandFromCache.Inst[commandFrom];
        }
    }
}
