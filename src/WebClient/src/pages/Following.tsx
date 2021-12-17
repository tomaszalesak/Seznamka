import { Grid } from '@mui/material';
import { useEffect, useState } from 'react';

import FindCard from '../components/FindCard';
import { useLogginUser } from '../hooks/useLoggedInUser';
import { FindUsers } from '../utils/types';

const Following = () => {
  const [logUser, _setLogUser] = useLogginUser();
  const [findUsers, setfindUsers] = useState<FindUsers>({ users: [], totalNumberOfUsers: 1 });

  // useEffect(() => {
  //   const getProfile = async () => {
  //     if (logUser?.jwt) {
  //       const config = {
  //         method: 'get' as Method,
  //         url: 'https://localhost:7298/api/Ban/banned',
  //         headers: {
  //           accept: 'text/plain',
  //           Authorization: `Bearer ${logUser.jwt}`
  //         }
  //       };

  //       const { data: response } = await axios(config);
  //       setFindUsers(response);
  //     }
  //   };
  //   getProfile();
  // }, []);

  return (
    <Grid container spacing={4}>
      {findUsers.users.map((user, index) => (
        <FindCard key={index} {...user} />
      ))}
    </Grid>
  );
};

export default Following;
