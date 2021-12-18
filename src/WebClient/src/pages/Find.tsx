import { Grid, Chip } from '@mui/material';
import { useEffect, useState } from 'react';
import axios, { Method } from 'axios';
import Pagination from '@mui/material/Pagination';

import FindCard from '../components/FindCard';
import { FindUsers } from '../utils/types';
import { useLogginUser } from '../hooks/useLoggedInUser';

type ChipData = {
  key: number;
  label: string;
  used: boolean;
};

// GET
// /api/User/find?age=true&height=true&weight=false&page=3
// create UserDto type

const Find = () => {
  const [logUser, _setLogUser] = useLogginUser();

  const [findUsers, setFindUsers] = useState<FindUsers>({ users: [], totalNumberOfUsers: 1 });
  const [page, setPage] = useState(1);
  const [countPages, setCountPages] = useState(1);

  const [chipData, setChipData] = useState<readonly ChipData[]>([
    { key: 0, label: 'Age', used: false },
    { key: 1, label: 'Height', used: false },
    { key: 2, label: 'Weight', used: false }
    // { key: 3, label: 'GPS radius', used: false }
  ]);

  // const ageFromDateOfBirthday = (dateOfBirth: string) => {
  //   const today = new Date();
  //   const birthDate = dateOfBirth.split('.');
  //   let age = today.getFullYear() - (birthDate?.[2] as unknown as number);
  //   const m = today.getMonth() - (birthDate?.[1] as unknown as number);

  //   if (m < 0 || (m === 0 && today.getDate() < (birthDate?.[0] as unknown as number))) {
  //     age--;
  //   }

  //   return age;
  // };

  const PageChange = (_event: React.ChangeEvent<unknown>, value: number) => {
    setPage(value);
  };

  const loadData = async () => {
    if (logUser?.jwt) {
      const config = {
        method: 'get' as Method,
        url: 'https://localhost:7298/api/User/find',
        params: {
          age: chipData[0].used,
          height: chipData[1].used,
          weight: chipData[2].used,
          page
        },
        headers: {
          accept: 'text/plain',
          Authorization: `Bearer ${logUser.jwt}`
        }
      };

      const { data: response } = await axios(config);
      setFindUsers(response);
    }
  };

  const setPagesCount = () => {
    let pages = Math.floor(findUsers.totalNumberOfUsers / 10);
    pages = findUsers.totalNumberOfUsers % 10 ? pages + 1 : pages;
    setCountPages(pages ? pages : 1);
  };

  useEffect(() => {
    (async () => {
      try {
        await loadData();
        setPage(1);
      } catch (err) {
        console.log((err as { message?: string })?.message ?? 'Unknown error occurred');
      }
    })();
  }, [chipData]);

  useEffect(() => {
    setPagesCount();
  }, [findUsers.totalNumberOfUsers]);

  useEffect(() => {
    (async () => {
      try {
        await loadData();
      } catch (err) {
        console.log((err as { message?: string })?.message ?? 'Unknown error occurred');
      }
    })();
  }, [page]);

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
      <br />
      <br />
      <Pagination
        count={countPages}
        page={page}
        onChange={PageChange}
        variant="outlined"
        color="secondary"
      />
    </>
  );
};

export default Find;
