import { useState } from 'react'
import { ToastContainer } from 'react-toastify'
import { FileUpload } from './FileUpload'
import { convertFile } from './helpers/DownloadHelper';

function App() {
    const [ file, setFile ] = useState<File>();

    return (
        <>
            <ToastContainer
                theme='colored'
            />
            {!file
            ? <FileUpload
                onDrop={files => files.length > 0 ? setFile(files[0]) : setFile(undefined)}
            /> : <h3>{file.name}</h3>}
            <button 
                onClick={() => convertFile('http://localhost:5041/api/convert', file!)} 
                disabled={!file}
            >
                Convert
            </button>
        </>
    )
}

export default App
