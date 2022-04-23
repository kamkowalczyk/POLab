using lab4_TimePeriod;
using System;
using Xunit;

namespace TestTimeTimePeriod
{
    public class Tests
    {
        #region Time structure unit tests

        [Fact]
        public void Time_ShouldReturnTrue_Operator_Equals()
        {
           
            var expected = true;
            
            Time timeOne = new Time(0, 0, 0);
            Time timeTwo = new Time(0, 0, 0);
            var actual = (timeOne == timeTwo);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Time_ShouldReturnFalse_Operator_DiffenceEquals()
        {
          
            var expected = false;
           
            Time timeOne = new Time(0, 0, 0);
            Time timeTwo = new Time(0, 0, 0);
            var actual = (timeOne != timeTwo);
         
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Time_ShouldReturnTrue_Operator_Less()
        {
            var expected = true;
          
            Time timeOne = new Time(0, 0, 0);
            Time timeTwo = new Time(1, 1, 1);
            var actual = (timeOne < timeTwo);
         
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Time_ShouldReturnFalse_Operator_Greater()
        {
          
            var expected = false;
           
            Time timeOne = new Time(0, 0, 0);
            Time timeTwo = new Time(1, 1, 1);
            var actual = (timeOne > timeTwo);
           
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Time_ShouldReturnTrue_Operator_GreaterOrEqual()
        {
           
            var expected = true;
           
            Time timeOne = new Time(0, 0, 0);
            Time timeTwo = new Time(1, 1, 1);
            Time timeThree = new Time(1, 1, 1);
            var actual = (timeTwo >= timeOne && timeThree >= timeTwo);
            
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Time_ShouldReturnTrue_Operator_LessrOrEqual()
        {
            
            var expected = true;
          
            Time timeOne = new Time(0, 0, 0);
            Time timeTwo = new Time(1, 1, 1);
            Time timeThree = new Time(1, 1, 1);
            var actual = (timeOne <= timeTwo && timeThree <= timeTwo);
           
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Time_ShouldReturnTrue_Operator_Minus()
        {
            
            var expected = true;
         
            Time timeOne = new Time(2, 2, 2);
            Time timeTwo = new Time(1, 1, 1);
            Time timeThree = new Time(1, 1, 1);
            var actual = (timeThree == (timeOne - timeTwo));
          
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Time_ShouldReturnTrue_Operator_Plus()
        {
            
            var expected = true;
          
            Time timeOne = new Time(1, 1, 1);
            Time timeTwo = new Time(1, 1, 1);
            Time timeThree = new Time(2, 2, 2);
            var actual = (timeThree == (timeOne + timeTwo));
          
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void Time_ShouldReturnTrue_ToString()
        {
          
            var expected = true;
         
            Time time = new Time(0, 0, 0);
            var actual = ("00:00:00" == time.ToString());
          
            Assert.Equal(expected, actual);
        }

        #endregion

        #region TimePeriod structure unit tests

        [Fact]
        public void TimePeriod_ShouldReturnTrue_Operator_Equals()
        {
            
            var expected = true;
         
            TimePeriod timeOne = new TimePeriod(0, 0, 0);
            TimePeriod timeTwo = new TimePeriod(0, 0, 0);
            var actual = (timeOne == timeTwo);
        
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TimePeriod_ShouldReturnFalse_Operator_DiffenceEquals()
        {
           
            var expected = false;
           
            TimePeriod timeOne = new TimePeriod(0, 0, 0);
            TimePeriod timeTwo = new TimePeriod(0, 0, 0);
            var actual = (timeOne != timeTwo);
           
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TimePeriod_ShouldReturnTrue_Operator_Less()
        {
          
            var expected = true;
          
            TimePeriod timeOne = new TimePeriod(0, 0, 0);
            TimePeriod timeTwo = new TimePeriod(1, 1, 1);
            var actual = (timeOne < timeTwo);
            
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TimePeriod_ShouldReturnFalse_Operator_Greater()
        {
           
            var expected = false;
          
            TimePeriod timeOne = new TimePeriod(0, 0, 0);
            TimePeriod timeTwo = new TimePeriod(1, 1, 1);
            var actual = (timeOne > timeTwo);
           
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TimePeriod_ShouldReturnTrue_Operator_GreaterOrEqual()
        {
            var expected = true;
           
            TimePeriod timeOne = new TimePeriod(0, 0, 0);
            TimePeriod timeTwo = new TimePeriod(1, 1, 1);
            TimePeriod timeThree = new TimePeriod(1, 1, 1);
            var actual = (timeTwo >= timeOne && timeThree >= timeTwo);
           
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TimePeriod_ShouldReturnTrue_Operator_LessrOrEqual()
        {
            
            var expected = true;
         
            TimePeriod timeOne = new TimePeriod(0, 0, 0);
            TimePeriod timeTwo = new TimePeriod(1, 1, 1);
            TimePeriod timeThree = new TimePeriod(1, 1, 1);
            var actual = (timeOne <= timeTwo && timeThree <= timeTwo);
         
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TimePeriod_ShouldReturnTrue_Operator_Plus()
        {

            var expected = true;
        
            TimePeriod timeOne = new TimePeriod(1, 1, 1);
            TimePeriod timeTwo = new TimePeriod(1, 1, 1);
            TimePeriod timeThree = new TimePeriod(2, 2, 2);
            var actual = (timeThree == (timeOne + timeTwo));
           
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void TimePeriod_ShouldReturnTrue_ToString()
        {
            
            var expected = true;
         
            TimePeriod time = new TimePeriod(123, 0, 0);
            var actual = ("123:00:00" == time.ToString());
          
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TimePeriod_ShouldReturnTrue_Static_Plus()
        {
           
            var expected = new TimePeriod(2, 2, 2);
          
            TimePeriod timeOne = new TimePeriod(1, 1, 1);
            TimePeriod timeTwo = new TimePeriod(1, 1, 1);


            var actual = TimePeriod.Plus(timeOne, timeTwo);
          
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TimePeriod_ShouldReturnTrue_Plus()
        {
           
            var expected = new TimePeriod(2, 2, 2);
         
            TimePeriod timeOne = new TimePeriod(1, 1, 1);
            TimePeriod timeTwo = new TimePeriod(1, 1, 1);


            var actual = timeOne.Plus(timeTwo);
          
            Assert.Equal(expected, actual);
        }
        #endregion
    }
}
