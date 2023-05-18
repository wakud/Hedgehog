using System;

namespace Hedgehog.BLL
{
    public interface IHedgehogMeeting
    {
        int GetMinimumMeetings(int desiredColor, int[] population);
    }
}
