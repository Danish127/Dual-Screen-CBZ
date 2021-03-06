using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using AndroidX.ViewPager2.Adapter;

namespace DualScreenCBZ
{
	public class PagerAdapter : FragmentPagerAdapter //FragmentStateAdapter //FragmentPagerAdapter
	{
		List<TestFragment> fragments;

		public bool ShowTwoPages { get; set; } = false;

		public bool FirstPageOffset { get; set; } = false;

		public bool MangaOrganization { get; set; } = false;

		public PagerAdapter(FragmentManager fm, List<TestFragment> fragments)
			: base(fm, BehaviorResumeOnlyCurrentFragment)
		{
			this.fragments = fragments;
		}

		public override Fragment GetItem(int position)
		{

			position++;
			if (ShowTwoPages)
			{

				//fragments[position].FragmentManager.PopBackStack();
				if (FirstPageOffset)
				{
					position--;
                }
                else
                {
					position++;
                }
			}

			return fragments[position];

			
			if (ShowTwoPages)
			{
				return fragments[position];
			}
			else
			{
				return fragments[position];
			}
		}

		public override int Count
			=> fragments.Count;

        //public override int ItemCount => throw new NotImplementedException();

        // 0.5f : Each pages occupy full space
        // 1.0f : Each pages occupy half space
        public override float GetPageWidth(int position)
			=> ShowTwoPages ? 0.5f : 1.0f;

        /*public override Fragment CreateFragment(int p0)
        {
            throw new NotImplementedException();
        }*/
    }
}