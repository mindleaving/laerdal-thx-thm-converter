import { toast } from "react-toastify";
import { ToastContent } from "../components/ToastContent";

export const showSuccessAlert = (title: string, message?: string, durationInMs?: number) => {
    toast.success(<ToastContent title={title} message={message} />, {
        autoClose: durationInMs
    });
}
export const showWarningAlert = (title: string, message?: string, durationInMs?: number) => {
    toast.warning(<ToastContent title={title} message={message} />, {
        autoClose: durationInMs
    });
}
export const showErrorAlert = (title: string, message?: string, durationInMs?: number) => {
    toast.error(<ToastContent title={title} message={message} />, {
        autoClose: durationInMs
    });
}
export const showInfoAlert = (title: string, message?: string, durationInMs?: number) => {
    toast.info(<ToastContent title={title} message={message} />, {
        autoClose: durationInMs
    });
}