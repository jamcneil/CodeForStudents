using System;
using Android.OS;

namespace TestTimer
{
	public class MyTimer: CountDownTimer
	{
		Action onTick;
		Action onFinish;

		public MyTimer(long millisInFuture, long countDownInterval, Action onTick, Action onFinish)
			:base(millisInFuture, countDownInterval)
		{
			this.onTick = onTick;
			this.onFinish = onFinish;

		}

		public override void OnFinish ()
		{
			onFinish ();
		}

		public override void OnTick (long millisUntilFinished)
		{
			onTick ();
		}
	}
}
