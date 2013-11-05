using System;
using ProjectTemplate.Application.Requests;
using ProjectTemplate.Domain.Common;
using ProjectTemplate.WCF.Common.ErrorHandling;
using ProjectTemplate.WCF.Common.SessionHandling;
using ProjectTemplate.WCF.DataTransferObjects;
using StructureMap;

namespace ProjectTemplate.WCF
{
    [ErrorHandingBehavior]
    [SessionClosingBehaviour]
    public class TaskService : ITaskService
    {
        private readonly Application.Contracts.ITaskService _taskService;

        //todo: there is a better way to do IOC with WCF, but haven't got it working.
        public TaskService()
        {
            _taskService = ObjectFactory.GetInstance<Application.Contracts.ITaskService>();
        }

        public TaskService(Application.Contracts.ITaskService taskService)
        {
            _taskService = taskService;
        }

        public TaskDto[] GetAll()
        {
            throw new NotImplementedException();
            //return TaskDtoMapper.Map(_taskService.GetAll()).ToArray();
        }

        public TaskDto GetById(Guid id)
        {
            throw new NotImplementedException();
            //return TaskDtoMapper.Map(_taskService.GetById(id));
        }

        public ValidationMessageCollection ValidateRaise(RaiseTaskRequest request)
        {
            return _taskService.ValidateRaise(request);
        }

        public Guid Raise(RaiseTaskRequest request)
        {
            return _taskService.Raise(request);
        }
    }
}
