#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Windows.Storage.AccessCache
{
	#if __ANDROID__ || __IOS__ || NET46 || __WASM__
	#if __ANDROID__ || __IOS__ || NET46 || __WASM__
	[global::Uno.NotImplemented]
	#endif
	public   enum RecentStorageItemVisibility 
	{
		#if __ANDROID__ || __IOS__ || NET46 || __WASM__
		AppOnly,
		#endif
		#if __ANDROID__ || __IOS__ || NET46 || __WASM__
		AppAndSystem,
		#endif
	}
	#endif
}
