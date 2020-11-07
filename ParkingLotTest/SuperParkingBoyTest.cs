namespace ParkingLotTest
{
    using System;
    using System.Collections.Generic;
    using Moq;
    using ParkingLot;
    using Xunit;

    public class SuperParkingBoyTest
    {
        [Fact]
        public void Should_park_to_parking_lot_has_larger_available_position_rate()
        {
            // given
            ParkingLot firstParkingLot = new ParkingLot(3);
            ParkingLot secondParkingLot = new ParkingLot(4);
            ParkingLot thirdParkingLot = new ParkingLot(5);
            SuperParkingBoy parkingBoy = new SuperParkingBoy(new List<ParkingLot>
            {
                firstParkingLot,
                secondParkingLot,
                thirdParkingLot,
            });

            // when
            for (int i = 1; i <= 7; i++)
            {
                parkingBoy.Park(new Car());
            }

            // then
            Assert.Equal(1, firstParkingLot.AvailablePositions());
            Assert.Equal(2, secondParkingLot.AvailablePositions());
            Assert.Equal(2, thirdParkingLot.AvailablePositions());
        }
    }
}
