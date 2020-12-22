using SmartSql;
using System;

namespace Infrastructure
{
    /// <summary>
    /// 暂时不用
    /// </summary>
    public class DbInstance
    {
        private static SmartSqlBuilder smartSqlBuilder;
        public static void InitSmartSql()
        {
            if (smartSqlBuilder == null)
            {
                smartSqlBuilder =
                    new SmartSqlBuilder()
                .UseXmlConfig()
                .Build();
            }
        }
        public static SmartSqlBuilder GetSmartSqlBuilder() {
            if (smartSqlBuilder == null)
            {
                smartSqlBuilder =
                    new SmartSqlBuilder()
                .UseXmlConfig()
                .Build();
            }
            return smartSqlBuilder;
        }
    }
}
