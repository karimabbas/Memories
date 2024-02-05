// import React, { useState } from 'react'
// import { Button, CardBody, Col, ListGroupItem, Row } from 'reactstrap'
// import { FileText, X, DownloadCloud, Image } from 'react-feather'
// import { useDropzone } from 'react-dropzone'
// import {renderFilePreview as renderFileIcon }from './attachment'

// const UploadFiles = () => {

//     const [files, setFiles] = useState([]);
//     const [fileUploaded, setFileUploaded] = useState([]);

//     const { getRootProps, getInputProps } = useDropzone({
//         onDrop: acceptedFiles => {
//             setFiles([...files, ...acceptedFiles])
//             console.log(acceptedFiles)
//         },
//     })
//     console.log(files)

//     const renderFilePreview = file => {
//         console.log(file)
//         if (file.type.startsWith('image')) {
//             return <img className='rounded' alt={file.name} src={URL.createObjectURL(file)} height='28' width='28' />
//         } else {
//             return renderFileIcon({ extension: file.path })
//             // return <FileText size='28' />
//         }
//     }
//     const renderFileUploadedPreview = file => {
//         return renderFileIcon(file)
//     }

//     const handleRemoveFile = file => {
//         const uploadedFiles = files
//         const filtered = uploadedFiles.filter(i => i.name !== file.name)
//         setFiles([...filtered])
//     }

//     const renderFileSize = size => {
//         if (Math.round(size / 100) / 10 > 1000) {
//             return `${(Math.round(size / 100) / 10000).toFixed(1)} mb`
//         } else {
//             return `${(Math.round(size / 100) / 10).toFixed(1)} kb`
//         }
//     }

//     const displayImagesOnPage = (successful, mesg, response) => {
//         if (!successful) { // On error
//           console.error(`Failed:  ${mesg}`)
//           return
//         }
//         if (successful && mesg !== null && mesg.toLowerCase().indexOf('user cancel') >= 0) { // User cancelled.
//           console.info('User cancelled')
//           return
//         }
//         const scannedImages = scanner.getScannedImages(response, true, false) // returns an array of ScannedImage
//         for (let i = 0;
//           (scannedImages instanceof Array) && i < scannedImages.length; i++) {
//           const scannedImage = scannedImages[i]
//           const elementImg = scanner.createDomElementFromModel({
//             name: 'img',
//             attributes: {
//               class: 'scanned',
//               src: scannedImage.src
//             }
//           })
//           const file = dataURLtoFile(scannedImage.src, 'scanner_img.png')
//           setFiles((prevState) => {
//             return [...prevState, file]
//           })
//           // (document.getElementById('images') ? document.getElementById('images') : document.body).appendChild(elementImg)
//         }
//       }
//       const displayPdfOnPage = (successful, mesg, response) => {
//         if (!successful) { // On error
//           console.error(`Failed:  ${mesg}`)
//           return
//         }
//         if (successful && mesg !== null && mesg.toLowerCase().indexOf('user cancel') >= 0) { // User cancelled.
//           console.info('User cancelled')
//           return
//         }
//         const scannedImages = scanner.getScannedImages(response, true, false) // returns an array of ScannedImage
//         for (let i = 0;
//           (scannedImages instanceof Array) && i < scannedImages.length; i++) {
//           const scannedImage = scannedImages[i]
//           const elementImg = scanner.createDomElementFromModel({
//             name: 'img',
//             attributes: {
//               class: 'scanned',
//               src: scannedImage.src
//             }
//           })
//           const file = dataURLtoFile(scannedImage.src, 'scanner_Pdf.pdf')
//           setFiles((prevState) => {
//             return [...prevState, file]
//           })
//           // (document.getElementById('images') ? document.getElementById('images') : document.body).appendChild(elementImg)
//         }
//       }

//     const fileList = files.map((file, index) => (
//         <ListGroupItem key={`${file.name}-${index}`} className='d-flex align-items-center justify-content-between'>
//             <div className='file-details d-flex align-items-center'>
//                 <div className='file-preview mr-1'>{renderFilePreview(file)}</div>
//                 <div>
//                     <p className='file-name mb-0'>{file.name}</p>
//                     <p className='file-size mb-0'>{renderFileSize(file.size)}</p>
//                 </div>
//             </div>
//             <Button color='danger' outline size='sm' className='btn-icon' onClick={() => handleRemoveFile(file)}>
//                 <X size={14} />
//             </Button>
//         </ListGroupItem>
//     ))

//     return (
//         <>
//             <CardBody>
//                 <Row>
//                     <Col md='11' sm='12'>
//                         <div {...getRootProps({ className: 'dropzone' })}>
//                             <input {...getInputProps()} />
//                             <div className='d-flex align-items-center justify-content-center flex-column'>
//                                 <DownloadCloud size={64} />
//                                 <h5>اسحب الملفات او اضغط هنا</h5>
//                                 <p className='text-secondary'>
//                                     اسحب الملفات او اضغط {' '}
//                                     <a href='/' onClick={e => e.preventDefault()}>
//                                         تصفح
//                                     </a>{' '}
//                                     داخل الجهاز
//                                 </p>
//                             </div>
//                         </div>
//                     </Col>
//                     <Col md='1' sm='12'>
//                         <div className='col-md-1 col-sm-12 px-0 '>
//                             {/* <img src={Photos} style={{ cursor: 'pointer', width: '32px', margin: '5px 5px 0 0' }} onClick={() => scan('image')} /> */}
//                             {/* <img src={Pdf} style={{ cursor: 'pointer', width: '32px', margin: '5px 5px 0 0' }} onClick={() => scan('pdf')} /> */}
//                         </div>
//                     </Col>
//                 </Row>
//             </CardBody>

//         </>
//     )
// }

// export default UploadFiles
