using System;

namespace SmsService
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Anno.Const.Attribute;
    using Anno.EngineData;
    using Anno.Loader;
    using Anno.Log;
    using Anno.Rpc.Server;
    using Anno.Rpc.Storage;
    using Microsoft.Extensions.DependencyInjection;
    using Infrastructure;

    class Program
    {
        static void Main(string[] args)
        {
            if (args.Contains("-help"))
            {
                Log.ConsoleWriteLine(@"
启动参数：
	-p 6659		设置启动端口
	-xt 200		设置服务最大线程数
	-t 20000		设置超时时间（单位毫秒）
	-w 1		设置权重
	-h 192.168.0.2	设置服务在注册中心的地址
	-tr false		设置调用链追踪是否启用");
                return;
            }
            /**
             * 启动默认DI库为 Autofac 可以切换为微软自带的DI库 DependencyInjection
             */
            Bootstrap.StartUp(args, () =>//服务配置文件读取完成后回调(服务未启动)
            {
                var services = IocLoader.GetServiceDescriptors();
                services.AddSingleton<IRpcConnector, RpcConnectorImpl>();
                services.AddLogging();
                #region smartsql
                services
                 .AddSmartSql((sp, builder) =>
                 {
                     //builder.UseProperties(Configuration);                    
                 })
                 .AddRepositoryFromAssembly(o =>
                 {
                     o.AssemblyString = "Anno.Plugs.SmsService";
                     o.Filter = (type) => type.Namespace == "Anno.Plugs.SmsService.DyRepositories";
                 })
                 .AddInvokeSync(options => { });
                #endregion
            }
            , () =>//服务启动后的回调方法
            {
                /**
                 * 服务Api文档写入注册中心
                 */
               Bootstrap.ApiDoc();

                var provicer = IocLoader.Resolve<IServiceProvider>();
                provicer.UseSmartSqlSync();
                provicer.UseSmartSqlSubscriber((syncRequest) =>
                {
                    Console.Error.WriteLine(syncRequest.Scope);
                });
            }
            , IocType.DependencyInjection);
        }
    }
}
