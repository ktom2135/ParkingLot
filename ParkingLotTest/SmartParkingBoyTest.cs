namespace ParkingLotTest
{
    using System;
    using System.Collections.Generic;
    using Moq;
    using ParkingLot;
    using Xunit;

    public class SmartParkingBoyTest
    {
        [Fact]
        public void Should_park_to_parking_lot_has_most_available_positions()
        {
            // given
            Car car = new Car();
            Mock<ParkingLot> firstParkingLot = new Mock<ParkingLot>(5);
            Mock<ParkingLot> secondParkingLot = new Mock<ParkingLot>(10);
            Mock<ParkingLot> thirdParkingLot = new Mock<ParkingLot>(15);
            thirdParkingLot.Setup(mock => mock.Park(It.IsAny<Car>())).Returns(new Ticket());
            SmartParkingBoy parkingBoy = new SmartParkingBoy(new List<ParkingLot>
            {
                firstParkingLot.Object,
                secondParkingLot.Object,
                thirdParkingLot.Object,
            });

            // when
            Ticket ticket = parkingBoy.Park(car);

            // then
            thirdParkingLot.Verify(parkingLot => parkingLot.Park(car));
        }
    }
}
