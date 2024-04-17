using Microsoft.JSInterop;

namespace PropiedadesBlazor.Helpers
{
	public static class IJsHelper
	{
		public static async ValueTask ToastrSuccess(this IJSRuntime JSRuntime, string message)
		{ 
			await JSRuntime.InvokeVoidAsync("showToastr", "success", message);
		}

		public static async ValueTask ToastrError(this IJSRuntime JSRuntime, string message)
		{ 
			await JSRuntime.InvokeVoidAsync("showToastr", "error", message);
		}

		public static async ValueTask SwalSuccess(this IJSRuntime JSRuntime, string message)
		{
			await JSRuntime.InvokeVoidAsync("showSwal", "success", message);
		}
		public static async ValueTask SwalError(this IJSRuntime JSRuntime, string message)
		{
			await JSRuntime.InvokeVoidAsync("showSwal", "error", message);
		}
	}
}
