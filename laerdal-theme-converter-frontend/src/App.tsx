import { useCallback, useEffect, useState } from 'react'
import { ToastContainer } from 'react-toastify'
import { FileUpload } from './FileUpload'
import { download } from './helpers/DownloadHelper';
import { Alert, Button, CloseButton, Col, Container, Row, Spinner } from 'react-bootstrap';
import { showErrorAlert } from './helpers/AlertHelpers';

function App() {

    const [ hasAcceptedTerms, setHasAcceptedTerms ] = useState<boolean>(false);
    const [ file, setFile ] = useState<File>();
    const [ isConverting, setIsConverting ] = useState<boolean>(false);
    const [ isConverted, setIsConverted ] = useState<boolean>(false);

    useEffect(() => {
        setIsConverted(false);
    }, [ file ]);

    useEffect(() => {
        if(!isConverted) {
            return;
        }
        setTimeout(() => setFile(undefined), 3000);
    }, [ isConverted ]);

    const convert = useCallback(async () => {
        if(!file) {
            showErrorAlert("No file selected");
            return;
        }
        try {
            const url = window.location.hostname.toLowerCase() === "localhost"
                ? 'http://localhost:5041/api/convert'
                : `https://${window.location.hostname}/api/convert`;
            setIsConverting(true);
            const response = await fetch(url, {
                method: "POST",
                body: file,
                headers: {
                    "X-FileName": file.name
                }
            });
            if(!response.ok) {
                throw new Error(await response.text());
            }
            await download(response);
            setIsConverted(true);
        } catch(error: unknown) {
            showErrorAlert("Could not download converted file", (error as Error).message);
        } finally {
            setIsConverting(false);
        }
    }, [ file ]);

    return (
    <>
    <ToastContainer
        theme='colored'
    />
    <Container>
        <Row style={{ marginTop: '60px '}}>
            <h3>Convert Laerdal SimDesigner Themes (.thx) <span className='text-nowrap'>-&gt;</span> SimPad Theme (.thm)</h3>
        </Row>
        <Row>
            <Alert variant='warning'>
                <h5>Terms and Conditions</h5>
                <p>This is a private project. It is not associated to or endorsed by Laerdal. Report any issues here: <a href="https://github.com/mindleaving/laerdal-thx-thm-converter/issues">GitHub</a></p>
                <p>Not all SimDesigner features are supported by SimPad. Unsupported features are silently ignored. Please check your SimPad themes file (.thm) after conversion to make sure it suits your simulation scenario.</p>
                {!hasAcceptedTerms
                ? <div className='text-center'>
                    <Button
                        onClick={() => setHasAcceptedTerms(true)}
                        size='sm'
                    >
                        Understood
                    </Button>
                </div> : null}
            </Alert>
        </Row>
        {hasAcceptedTerms
        ? <Row className='align-items-center'>
            <Col />
            <Col xs={3}>
                <img 
                    src="img/simdesigner.png" 
                    alt="SimDesigner"
                    width="100%"
                />
            </Col>
            <Col xs={4} lg={3} className='text-center'>
                <span 
                    className='display-5 text-secondary'
                >
                    <strong>======&gt;</strong>
                </span>
                {!file
                ? <FileUpload
                    onDrop={files => {
                        const thxFiles = files.filter(file => file.name.toLowerCase().endsWith('.thx'));
                        if(thxFiles.length === 0) {
                            setFile(undefined)
                        }
                        setFile(thxFiles[0]);
                    }}
                /> 
                : <Alert 
                    variant={isConverted ? "success" : "primary"}
                    className={`py-2 mb-0 border-${isConverted ? 'success' : 'primary'} border-2`}
                >
                    <Row className='align-items-center'>
                        <Col>
                            <span 
                                style={{ 
                                    fontSize: '1.2rem', 
                                    fontWeight: 'bold',
                                    color: isConverted ? '#073' : '#25a'
                                }} 
                            >
                                {file.name}
                            </span>
                        </Col>
                        <Col xs="auto">
                            <CloseButton
                                onClick={() => setFile(undefined)}
                            />
                        </Col>
                    </Row>
                </Alert>}
                <Button 
                    onClick={convert} 
                    disabled={isConverting || !file}
                    size='lg'
                    className='mt-2'
                >
                    {isConverting ? <Spinner className='me-2' /> : null} Convert
                </Button>
            </Col>
            <Col xs={3}>
                <img 
                    src="img/simpad-theme-editor.png" 
                    alt="SimPad Theme Editor"
                    width="100%"
                />
            </Col>
            <Col />
        </Row> : null}
        <Row className='mt-4'>
            <Col className='text-center'>
                <span className='text-secondary'>
                    <div className='d-inline-block me-1'><small>&copy; 2025 Created by Jan Scholtyssek &lt;jan@janscholtyssek.dk&gt;.</small></div>
                    <div className='d-inline-block'><small>Released under MIT license on <a href="https://github.com/mindleaving/laerdal-thx-thm-converter">GitHub</a>.</small></div>
                </span>
            </Col>
        </Row>
    </Container>
    </>);
}

export default App
