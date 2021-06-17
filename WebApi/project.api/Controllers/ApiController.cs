using Microsoft.AspNetCore.Mvc;
using project.application.Common.Models;
using project.domain.Notifications;
using System.Collections.Generic;

namespace project.api.Controllers
{
    public abstract class ApiController : ControllerBase
    {
        private readonly NotificationContext _notificationContext;

        protected ApiController(NotificationContext notificationContext)
        {
            _notificationContext = notificationContext;
        }

        protected IEnumerable<Notification> Notifications => _notificationContext.Notifications;

        protected bool IsValidOperation()
        {
            return (!_notificationContext.HasNotifications);
        }

        protected new IActionResult Response(CommandResponse result = null)
        {
            if (result == null)
            {
                return BadRequest();
            }

            result.Notifications = _notificationContext.HasNotifications ?
                                        _notificationContext.Notifications : null;

            return new ObjectResult(result) { StatusCode = result.StatusCode };
        }
    }
}
