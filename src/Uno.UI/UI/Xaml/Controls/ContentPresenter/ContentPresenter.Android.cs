﻿using Android.Views;
using Android.Widget;
using Uno.Logging;
using Uno.Extensions;
using Uno.UI.DataBinding;
using Uno.UI.Controls;
using Windows.UI.Xaml.Data;
using System;
using System.Collections.Generic;
using Uno.Disposables;
using System.Runtime.CompilerServices;
using System.Text;
using Android.Graphics;
using Android.Graphics.Drawables;
using System.Drawing;
using System.Linq;
using Uno.UI;

namespace Windows.UI.Xaml.Controls
{
	public partial class ContentPresenter
	{
		private BorderLayerRenderer _borderRenderer = new BorderLayerRenderer();

		public ContentPresenter()
		{
			InitializeContentPresenter();

			IFrameworkElementHelper.Initialize(this);

			this.RegisterLoadActions(UpdateBorder, () => _borderRenderer.Clear());
		}

		protected override void OnLayoutCore(bool changed, int left, int top, int right, int bottom)
		{
			base.OnLayoutCore(changed, left, top, right, bottom);

			UpdateBorder();
		}

		private void SetUpdateTemplate()
		{
			UpdateContentTemplateRoot();
			RequestLayout();
		}

		partial void RegisterContentTemplateRoot()
		{
			//This validation is present in order to remove the child from its parent if it already has a parent.
			//This prevents an exception for an InvalidState when we try to set a new template.
			if (ContentTemplateRoot.Parent != null)
			{
				(ContentTemplateRoot.Parent as ViewGroup)?.RemoveView(ContentTemplateRoot);
			}

			AddView(ContentTemplateRoot);
		}

		partial void UnregisterContentTemplateRoot()
		{
			this.RemoveViewAndDispose(ContentTemplateRoot);
		}

		private void UpdateBorder()
		{
			if (IsLoaded)
			{
				_borderRenderer.UpdateLayers(
					this,
					Background,
					BorderThickness,
					BorderBrush,
					CornerRadius,
					Padding
				);
			}
		}
	}
}
