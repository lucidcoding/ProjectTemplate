using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Moq;
using ProjectTemplate.Application.Contracts;
using ProjectTemplate.Application.Requests;
using ProjectTemplate.Domain.Common;
using ProjectTemplate.Domain.RepositoryContracts;
using ProjectTemplate.UI.Controllers;
using ProjectTemplate.UI.ViewModels;

namespace ProjectTemplate.UI.UnitTests.MockFactories.ControllerFactories
{
    public class TaskControllerFactory
    {
        private Mock<IPrincipal> _principal;
        private Mock<IIdentity> _identity;
        private Mock<HttpContextBase> _httpContext;
        private Mock<ControllerContext> _controllerContext;

        private Mock<IUserService> _userService;
        private Mock<ITaskService> _taskService;
        private Mock<ITaskRepository> _taskRepository;
        private Mock<ITaskTypeRepository> _taskTypeRepository;
        private Mock<IUserRepository> _userRepository;
        private TaskController _taskController;
        //private User _user1;
        //private User _user2;
        //private List<User> _users;
        //private TaskType _taskType1;
        //private TaskType _taskType2;
        //private List<TaskType> _taskTypes;
        //private Mock<Task> _task1;
        //private Mock<Task> _task2;
        //private List<Task> _tasks;

        public TaskController GetController()
        {
            _principal = new Mock<IPrincipal>();
            _identity = new Mock<IIdentity>();
            _httpContext = new Mock<HttpContextBase>();
            _controllerContext = new Mock<ControllerContext>();

            _taskService = new Mock<ITaskService>();
            _userService = new Mock<IUserService>();
            _taskRepository = new Mock<ITaskRepository>();
            _taskTypeRepository = new Mock<ITaskTypeRepository>();
            _userRepository = new Mock<IUserRepository>();

            _taskController = new TaskController(
                _taskService.Object,
                _userService.Object,
                _taskRepository.Object,
                _taskTypeRepository.Object,
                _userRepository.Object);

            _identity
                .SetupGet(x => x.Name)
                .Returns("Test Username 01");

            _principal
                .SetupGet(x => x.Identity)
                .Returns(_identity.Object);

            _httpContext
                .SetupGet(x => x.User)
                .Returns(_principal.Object);

            _controllerContext
                .SetupGet(x => x.HttpContext)
                .Returns(_httpContext.Object);


            _taskController.ControllerContext = _controllerContext.Object;

            var viewModel = new TaskRaiseEditViewModel
            {
                Description = "Raise Description 01",
                AssignedToId = Guid.NewGuid(),
                TypeId = Guid.NewGuid()
            };

            _taskService
                .Setup(x => x.ValidateRaise(It.IsAny<RaiseTaskRequest>()))
                .Returns(new ValidationMessageCollection());

            return _taskController;
        }
    }
}
