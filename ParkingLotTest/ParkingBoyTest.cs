namespace ParkingLotTest
{
    using ParkingLot;
    using Xunit;

    public class ParkingBoyTest
    {
        [Fact]
        public void Should_return_ticket_when_park_a_car()
        {
            // given
            Car car = new Car();
            ParkingBoy parkingBoy = new ParkingBoy();

            // when
            Ticket ticket = parkingBoy.Park(car);

            // then
            Assert.NotNull(ticket);
        }
    }
}
