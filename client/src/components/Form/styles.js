
import { makeStyles } from "@mui/styles";


export default makeStyles({
  root: {
    '& .MuiTextField-root': {
      // margin: theme.spacing(1),
    margin:3

    },
    margin:2
  },
  paper: {
    // padding: theme.spacing(2),
    padding:4,
    // marginTop:4,
    background: 'whitesmoke'
  },
  form: {
    display: 'flex',
    flexWrap: 'wrap',
    justifyContent: 'center',
  },
  fileInput: {
    width: '97%',
    margin: '11px 0',
  },
  buttonSubmit: {
    marginBottom:10
  },
});