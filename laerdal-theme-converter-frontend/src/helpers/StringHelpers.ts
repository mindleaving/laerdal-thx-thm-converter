export const removeSurroundingQuotes = (str: string | null | undefined) => {
    if(!str) {
        return str;
    }
    if((str.startsWith('\'') && str.endsWith('\''))
        || (str.startsWith('"') && str.endsWith('"'))) {
        return str.substring(1, str.length-1);
    }
    return str;
}