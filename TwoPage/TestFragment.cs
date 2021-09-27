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

namespace TwoPage
{
	public class TestFragment : Fragment
	{
		public MemoryStream ImageMemory { get; private set; }

		public static TestFragment NewInstance(MemoryStream Page)
		{
			var testFragment = new TestFragment()
			{
				ImageMemory = Page
			};
			return testFragment;
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			var view = inflater.Inflate(Resource.Layout.fragment_layout, container, false);
			var mImageView = view.FindViewById<ImageView>(Resource.Id.image_view);
			mImageView.SetImageDrawable(Drawable.CreateFromStream(ImageMemory, null));
			return view;
		}

		// Init fragments for ViewPager
		public static List<TestFragment> Fragments(List<MemoryStream> Pages) =>Pages.Select(i => TestFragment.NewInstance(i)).ToList();
	}
}