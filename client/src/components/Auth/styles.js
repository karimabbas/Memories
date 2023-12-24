import { red } from '@mui/material/colors';
import { makeStyles } from '@mui/styles';

export default makeStyles(() => ({
  paper: {
    // marginTop: theme.spacing(8),
    marginTop:8,
    display: 'flex',
    flexDirection: 'column',
    alignItems: 'center',
    padding:3,
    // padding: theme.spacing(2),
  },
  root: {
    '& .MuiTextField-root': {
      // margin: theme.spacing(1),
    margin:3

    },
    margin:2
  },
  avatar: {
    margin:2,
    // margin: theme.spacing(1),
    color:"red",
  },
  form: {
    width: '100%', // Fix IE 11 issue.
    // marginTop: theme.spacing(3),
    marginTop:6
  },
  submit: {
    margin: 3,
    // margin: theme.spacing(3, 0, 2),
  },
  googleButton: {
    marginBottom:5,
    // marginBottom: theme.spacing(2),
  },
  lock :{
    backgroundColor:"red"
  },
  empButton: {
    marginTop:20,
    marginLeft:50,
}
}));