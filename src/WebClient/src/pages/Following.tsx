import { Grid } from '@mui/material';
import axios, { Method } from 'axios';
import { useEffect, useState } from 'react';

import FindCard from '../components/FindCard';
import { useLogginUser } from '../hooks/useLoggedInUser';
import { Friendships } from '../utils/types';

const Following = () => {
  const [logUser, _setLogUser] = useLogginUser();
  const [findUsers, setfindUsers] = useState<Friendships[]>([]);

  useEffect(() => {
    const getProfile = async () => {
      if (logUser?.jwt) {
        const config = {
          method: 'get' as Method,
          url: 'https://localhost:7298/api/User',
          headers: {
            accept: 'text/plain',
            Authorization: `Bearer ${logUser.jwt}`
          }
        };

        const { data: response } = await axios(config);
        setfindUsers(response.friendships);
      }
    };
    getProfile();
  }, []);

  return (
    <Grid container spacing={4}>
      {findUsers.map((user, index) => (
        <FindCard key={index} {...user.friend} />
      ))}
    </Grid>
  );
};

export default Following;
