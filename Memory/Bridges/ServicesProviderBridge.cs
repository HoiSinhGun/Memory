using Memory.Console.Command.Commands;
using Memory.Console.Command.Services;
using Memory.Data.DAO;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Memory.Bridges
{

    public class ServicesProviderBridge
    {
        public readonly List<Type> modelKeyDaoList = new List<Type>();

        public readonly IServiceProvider _serviceProvider;
        public readonly Dictionary<Type, IExecutor> _executorDict = new Dictionary<Type, IExecutor>();
        public readonly Dictionary<Type, IModelKeyDAO> _modelKeyDAODict = new Dictionary<Type, IModelKeyDAO>();

        public ServicesProviderBridge(IServiceProvider serviceProvider)
        {
            initializeLists();

            _serviceProvider = serviceProvider;

            {
                _executorDict.Add(typeof(ModelKeyMetaListExe), new ModelKeyMetaListExe());
            }
            {
                foreach (Type type in modelKeyDaoList)
                {
                    var service = (IModelKeyDAO) _serviceProvider.GetRequiredService(type);
                    _modelKeyDAODict.Add(type, service);
                }
            }
        }

        private void initializeLists()
        {
            modelKeyDaoList.Add(typeof(AgentDAO));
            modelKeyDaoList.Add(typeof(PersonDAO));
            modelKeyDaoList.Add(typeof(MoneyTransferCategoryDAO));
        }

        public IExecutor GetCommandExecutorFor(String commandString)
        {
            var executorList = _executorDict.Values;

            foreach (var executor in executorList)
            {
                if (executor.Handle(commandString))
                    return executor;
            }

            return UnknownCommandExe.instance;
        }
    }
}
