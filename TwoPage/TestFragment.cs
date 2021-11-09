using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;

namespace DualScreenCBZ
{
	public class TestFragment : Fragment
	{
		public byte[] ImageMemory { get; private set; }
		public int PageNumber { get; private set; }

		public static TestFragment NewInstance(byte[] Page, int PageNumber)
		{
			var testFragment = new TestFragment()
			{
				ImageMemory = Page,
				PageNumber = PageNumber + 1
			};
			return testFragment;
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			try
			{
				var view = inflater.Inflate(Resource.Layout.fragment_layout, container, false);
				var mImageView = view.FindViewById<ImageView>(Resource.Id.image_view);
				if (ImageMemory.Length > 0)
				{
					mImageView.SetImageBitmap(BitmapFactory.DecodeByteArray(ImageMemory, 0, ImageMemory.Length));
				}
				return view;
            }
            catch (Exception ex)
            {
				return null;
            }
		}

		// Init fragments for ViewPager
		public static List<TestFragment> Fragments(List<byte[]> Pages) =>Pages.Select(i => TestFragment.NewInstance(i, Pages.IndexOf(i))).ToList();
	}
}