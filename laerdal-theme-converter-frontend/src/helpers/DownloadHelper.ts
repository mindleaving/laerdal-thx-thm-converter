import { showErrorAlert } from "./AlertHelpers";
import { removeSurroundingQuotes } from "./StringHelpers";

export const convertFile = async (
    url: string,
    file: File) => {
    const anchor = document.createElement("a");
    document.body.appendChild(anchor);
    try {
        const response = await fetch(url, {
            method: "POST",
            body: file,
            headers: {
                "X-FileName": file.name
            }
        });
        const result = await response.blob();
        const contentDispositionHeader = response.headers.get("content-disposition");
        const filenameFromHeader = removeSurroundingQuotes(contentDispositionHeader
            ?.split(';')
            .map(x => x.trim())
            .find(x => x.toLowerCase().startsWith("filename="))
            ?.split('=')[1]
        );
        const filename = filenameFromHeader ?? 'document.bin';
        const objectUrl = window.URL.createObjectURL(result);
        anchor.href = objectUrl;
        anchor.download = filename;
        anchor.click();
        window.URL.revokeObjectURL(objectUrl);
    } catch(error: unknown) {
        showErrorAlert("Could not download converted file", (error as Error).message);
    } finally {
        document.body.removeChild(anchor);
    }
}