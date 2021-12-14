import { Button, Paper, TextField, Typography } from '@mui/material';
import { Box } from '@mui/system';
import { FormEvent, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import axios, { Method } from 'axios';

import useField from '../hooks/useField';
import { useLogginUser } from '../hooks/useLoggedInUser';

const Login = () => {
  const navigate = useNavigate();
  const [_logUser, setLogUser] = useLogginUser();
  const [email, usernameProps] = useField('email', true);
  const [password, passwordProps] = useField('password', true);

  const [submitError, setSubmitError] = useState<string>();

  const baseURL = 'https://localhost:7298/api/User/login';

  return (
    <div>
      <Paper
        component="form"
        onSubmit={async (e: FormEvent) => {
          e.preventDefault();

          try {
            const data = JSON.stringify({
              userName: email,
              password
            });

            const config = {
              method: 'POST' as Method,
              url: baseURL,
              headers: {
                'accept': '*/*',
                'Content-Type': 'application/json'
              },
              data
            };
            const { data: response } = await axios(config);
            setLogUser({ jwt: response });
            console.log(response);
            navigate('/');
          } catch (err) {
            setSubmitError((err as { message?: string })?.message ?? 'Unknown error occurred');
          }
        }}
        sx={{
          display: 'flex',
          flexDirection: 'column',
          width: '100%',
          p: 4,
          gap: 2
        }}
      >
        <Typography variant="h4" component="h2" textAlign="center" mb={3}>
          Login
        </Typography>
        <TextField label="Username" {...usernameProps} type="email" />
        <TextField label="Password" {...passwordProps} type="password" />
        <Box
          sx={{
            display: 'flex',
            gap: 2,
            alignItems: 'center',
            alignSelf: 'flex-end',
            mt: 2
          }}
        >
          {submitError && (
            <Typography variant="caption" textAlign="right" sx={{ color: 'error.main' }}>
              {submitError}
            </Typography>
          )}
          <Button
            variant="outlined"
            onClick={() => {
              navigate('/register');
            }}
          >
            Register
          </Button>
          <Button type="submit" variant="contained">
            Log In
          </Button>
        </Box>
      </Paper>
    </div>
  );
};

export default Login;
