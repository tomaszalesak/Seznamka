import { Grid, Chip } from '@mui/material';
import { useEffect, useState } from 'react';
import axios, { Method } from 'axios';

import FindCard from '../components/FindCard';
import { FindUsers, User } from '../utils/types';
import { useLogginUser } from '../hooks/useLoggedInUser';

type ChipData = {
  key: number;
  label: string;
  used: boolean;
};

// GET
// https://localhost:7298/api/User/find?age=true&height=true&weight=false&page=3
// create UserDto type

const Find = () => {
  const [logUser, _setLogUser] = useLogginUser();

  const [findUsers, setFindUsers] = useState<FindUsers>({ users: [], totalNumberOfUsers: 1 });
  const [profile, setProfile] = useState<User>();

  const baseURL = 'https://localhost:7298/api/User/find';

  const [chipData, setChipData] = useState<readonly ChipData[]>([
    { key: 0, label: 'Age', used: false },
    { key: 1, label: 'Height', used: false },
    { key: 2, label: 'Weight', used: false }
    // { key: 3, label: 'GPS radius', used: false }
  ]);

  const ageFromDateOfBirthday = (dateOfBirth: string) => {
    const today = new Date();
    const birthDate = dateOfBirth.split('.');
    let age = today.getFullYear() - (birthDate?.[2] as unknown as number);
    const m = today.getMonth() - (birthDate?.[1] as unknown as number);

    if (m < 0 || (m === 0 && today.getDate() < (birthDate?.[0] as unknown as number))) {
      age--;
    }

    return age;
  };

  useEffect(() => {
    (async () => {
      if (logUser?.jwt) {
        try {
          const config = {
            method: 'get' as Method,
            url: 'https://localhost:7298/api/User/find',
            params: {
              age: chipData[0].used,
              height: chipData[1].used,
              weight: chipData[2].used,
              page: 1
            },
            headers: {
              accept: 'text/plain',
              Authorization: `Bearer ${logUser.jwt}`
            }
          };

          const { data: response } = await axios(config);
          setFindUsers(response);
          console.log(response);
        } catch (err) {
          console.log((err as { message?: string })?.message ?? 'Unknown error occurred');
        }
      }
    })();
  }, [chipData]);

  // useEffect(() => {
  //   const fetchData = async () => {
  //     try {
  //       const { data: response } = await axios.get('/stuff/to/fetch');
  //       setUsers(response);
  //     } catch (error) {
  //       console.error(error.message);
  //     }
  //   }

  //   fetchData();
  // }, []);

  // useEffect(() => {
  //   // Call onSnapshot() to listen to changes
  //   const unsubscribe = onSnapshot(usersCollection, snapshot => {
  //     // Access .docs property of snapshot
  //     setUsers(
  //       snapshot.docs
  //         .filter(doc => doc.id !== loggedInUser?.email)
  //         .map(doc => ({ id: doc.id, ...doc.data() }))
  //     );
  //   });
  //   // Don't forget to unsubscribe from listening to changes
  //   return () => {
  //     unsubscribe();
  //   };
  // }, [loggedInUser]);

  // useEffect(() => {
  //   if (profile?.preferences) {
  //     const unsubscribe = onSnapshot(usersCollection, snapshot => {
  //       setUsers(
  //         snapshot.docs
  //           .filter(doc => doc.id !== loggedInUser?.email)
  //           .map(doc => ({ id: doc.id, ...doc.data() }))
  //       );
  //       if (chipData[0].used === true) {
  //         setUsers(
  //           users
  //             .filter(user => profile.preferences.min_age <= ageFromDateOfBirthday(user.birth))
  //             .filter(user => profile.preferences.max_age >= ageFromDateOfBirthday(user.birth))
  //         );
  //       }
  //       if (chipData[1].used === true) {
  //         setUsers(
  //           users
  //             .filter(user => profile.preferences.min_height <= user.height)
  //             .filter(user => profile.preferences.max_height >= user.height)
  //         );
  //       }
  //       if (chipData[2].used === true) {
  //         setUsers(
  //           users
  //             .filter(user => profile.preferences.min_weight <= user.weight)
  //             .filter(user => profile.preferences.max_weight >= user.weight)
  //         );
  //       }
  //       /*if (chipData[3].used === true) {
  //         setUsers(
  //           users
  //             .filter(user => profile.preferences.gps_radius >= 0)
  //             .filter(user => profile.preferences.gps_radius <= 100)
  //         );
  //       }*/
  //     });
  //     return () => {
  //       unsubscribe();
  //     };
  //   }
  // }, [chipData]);

  const addtoFilter = (chipToAdd: ChipData) => () => {
    setChipData(chips =>
      chips.map(chip => {
        if (chip.key === chipToAdd.key) {
          chip.used = true;
          return chip;
        }
        return chip;
      })
    );
  };

  const deleteFromFilter = (chipToDelete: ChipData) => () => {
    setChipData(chips =>
      chips.map(chip => {
        if (chip.key === chipToDelete.key) {
          chip.used = false;
          return chip;
        }
        return chip;
      })
    );
  };

  return (
    <>
      <Grid sx={{ mb: 2 }} container spacing={2}>
        {chipData.map(data => (
          <Grid key={data.key} item>
            <Chip
              variant={data.used ? 'filled' : 'outlined'}
              label={data.label}
              onClick={addtoFilter(data)}
              onDelete={deleteFromFilter(data)}
            />
          </Grid>
        ))}
      </Grid>

      <Grid container spacing={4}>
        {findUsers.users.map((user, index) => (
          <FindCard key={index} {...user} />
        ))}
      </Grid>
    </>
  );
};

export default Find;
