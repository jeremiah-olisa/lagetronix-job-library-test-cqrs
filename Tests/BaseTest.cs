using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class BaseTest
    {
        public Mock<IMediator> _mediator;

        public BaseTest(Mock<IMediator> mediator)
        {
            _mediator = mediator;
        }

    }
}
