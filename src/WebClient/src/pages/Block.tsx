import { Grid } from '@mui/material';
import axios, { Method } from 'axios';
import { useEffect, useState } from 'react';

import FindCard from '../components/FindCard';
import { useLogginUser } from '../hooks/useLoggedInUser';
import { Ban } from '../utils/types';

const Block = () => {
  const [logUser, _setLogUser] = useLogginUser();
  const [findUsers, setFindUsers] = useState<Ban[]>([]);

  useEffect(() => {
    const getProfile = async () => {
      if (logUser?.jwt) {
        const config = {
          method: 'get' as Method,
          url: 'https://localhost:7298/api/Ban/banned',
          headers: {
            accept: 'text/plain',
            Authorization: `Bearer ${logUser.jwt}`
          }
        };

        const { data: response } = await axios(config);
        setFindUsers(response);
      }
    };
    getProfile();
  }, []);

  return (
    <Grid container spacing={4}>
      {findUsers.map((user, index) => (
        <FindCard key={index} {...user.banned} />
      ))}
    </Grid>
  );
};

export default Block;
