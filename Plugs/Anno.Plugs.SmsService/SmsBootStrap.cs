using Anno.EngineData;
using System;

namespace Anno.Plugs.SmsService
{
    /// <summary>
    /// Anno.Plugs.SmsService 插件启动器
    /// DependsOn 依赖的类型程序集自动注入DI容器
    /// </summary>
    [DependsOn(
       //typeof(Repository.Bootstrap)
       )]
    public class SmsBootStrap : IPlugsConfigurationBootstrap
    {
        /// <summary>
        /// 依赖注入后
        /// </summary>
        public void ConfigurationBootstrap()
        {
            //throw new NotImplementedException();
        }
        /// <summary>
        /// 依赖注入前
        /// </summary>
        public void PreConfigurationBootstrap()
        {
            //throw new NotImplementedException();
        }
    }
}
