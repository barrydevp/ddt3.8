using Bussiness;
using log4net;
using SqlDataProvider.Data;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;

namespace Game.Server.Managers
{
    public class RankMgr
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private static ReaderWriterLock m_lock = new ReaderWriterLock();

        private static Dictionary<int, UserMatchInfo> _matchs;

        private static Dictionary<int, UserRankDateInfo> _newRanks;

        protected static Timer _timer;

        public static bool Init()
        {
			try
			{
				m_lock = new ReaderWriterLock();
				_matchs = new Dictionary<int, UserMatchInfo>();
				_newRanks = new Dictionary<int, UserRankDateInfo>();
				BeginTimer();
				return ReLoad();
			}
			catch (Exception exception)
			{
				if (log.IsErrorEnabled)
				{
					log.Error("RankMgr", exception);
				}
				return false;
			}
        }

        public static bool ReLoad()
        {
			try
			{
				Dictionary<int, UserMatchInfo> dictionary = new Dictionary<int, UserMatchInfo>();
				Dictionary<int, UserRankDateInfo> newRanks = new Dictionary<int, UserRankDateInfo>();
				if (LoadData(dictionary, newRanks))
				{
					m_lock.AcquireWriterLock(-1);
					try
					{
						_matchs = dictionary;
						_newRanks = newRanks;
						return true;
					}
					catch
					{
					}
					finally
					{
						m_lock.ReleaseWriterLock();
					}
				}
			}
			catch (Exception exception)
			{
				if (log.IsErrorEnabled)
				{
					log.Error("RankMgr", exception);
				}
			}
			return false;
        }

        public static UserMatchInfo FindRank(int UserID)
        {
			if (_matchs.ContainsKey(UserID))
			{
				return _matchs[UserID];
			}
			return null;
        }

        public static UserRankDateInfo FindRankDate(int UserID)
        {
			if (_newRanks.ContainsKey(UserID))
			{
				return _newRanks[UserID];
			}
			return null;
        }

        private static bool LoadData(Dictionary<int, UserMatchInfo> Match, Dictionary<int, UserRankDateInfo> NewRanks)
        {
			using (PlayerBussiness playerBussiness = new PlayerBussiness())
			{
				playerBussiness.UpdateRank();
				UserMatchInfo[] allUserMatchInfo = playerBussiness.GetAllUserMatchInfo();
				UserMatchInfo[] array = allUserMatchInfo;
				foreach (UserMatchInfo userMatchInfo in array)
				{
					if (!Match.ContainsKey(userMatchInfo.UserID))
					{
						Match.Add(userMatchInfo.UserID, userMatchInfo);
					}
				}
				UserRankDateInfo[] allUserRankDate = playerBussiness.GetAllUserRankDate();
				UserRankDateInfo[] array2 = allUserRankDate;
				foreach (UserRankDateInfo userRankDateInfo in array2)
				{
					if (!NewRanks.ContainsKey(userRankDateInfo.UserID))
					{
						NewRanks.Add(userRankDateInfo.UserID, userRankDateInfo);
					}
				}
			}
			return true;
        }

        public static void BeginTimer()
        {
			int num = 3600000;
			if (_timer == null)
			{
				_timer = new Timer(TimeCheck, null, num, num);
			}
			else
			{
				_timer.Change(num, num);
			}
        }

        protected static void TimeCheck(object sender)
        {
			try
			{
				int tickCount = Environment.TickCount;
				ThreadPriority priority = Thread.CurrentThread.Priority;
				Thread.CurrentThread.Priority = ThreadPriority.Lowest;
				ReLoad();
				Thread.CurrentThread.Priority = priority;
				tickCount = Environment.TickCount - tickCount;
			}
			catch (Exception ex)
			{
				Console.WriteLine("TimeCheck Rank: " + ex);
			}
        }

        public void StopTimer()
        {
			if (_timer != null)
			{
				_timer.Dispose();
				_timer = null;
			}
        }
    }
}
