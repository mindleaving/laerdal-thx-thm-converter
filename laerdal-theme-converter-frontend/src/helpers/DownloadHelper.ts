import { removeSurroundingQuotes } from "./StringHelpers";

export const download = async (
    response: Response) => {
    const anchor = document.createElement("a");
    document.body.appendChild(anchor);
    try {
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
    } finally {
        document.body.removeChild(anchor);
    }
}