import {
  Button,
  Card,
  CardActions,
  CardContent,
  CardMedia,
  Grid,
  Typography,
  ImageList,
  ImageListItem
} from '@mui/material';
import { useParams } from 'react-router-dom';
import { useEffect, useState } from 'react';
import axios, { Method } from 'axios';

import { useLogginUser } from '../hooks/useLoggedInUser';
import useProfilePicture from '../hooks/useProfilePicture';
import { User } from '../utils/types';

const itemData = [
  {
    img: 'https://images.unsplash.com/photo-1549388604-817d15aa0110',
    title: 'Bed'
  },
  {
    img: 'https://images.unsplash.com/photo-1525097487452-6278ff080c31',
    title: 'Books'
  },
  {
    img: 'https://images.unsplash.com/photo-1523413651479-597eb2da0ad6',
    title: 'Sink'
  },
  {
    img: 'https://images.unsplash.com/photo-1563298723-dcfebaa392e3',
    title: 'Kitchen'
  },
  {
    img: 'https://images.unsplash.com/photo-1588436706487-9d55d73a39e3',
    title: 'Blinds'
  },
  {
    img: 'https://images.unsplash.com/photo-1574180045827-681f8a1a9622',
    title: 'Chairs'
  },
  {
    img: 'https://images.unsplash.com/photo-1530731141654-5993c3016c77',
    title: 'Laptop'
  },
  {
    img: 'https://images.unsplash.com/photo-1481277542470-605612bd2d61',
    title: 'Doors'
  },
  {
    img: 'https://images.unsplash.com/photo-1517487881594-2787fef5ebf7',
    title: 'Coffee'
  },
  {
    img: 'https://images.unsplash.com/photo-1516455207990-7a41ce80f7ee',
    title: 'Storage'
  },
  {
    img: 'https://images.unsplash.com/photo-1597262975002-c5c3b14bbd62',
    title: 'Candle'
  },
  {
    img: 'https://images.unsplash.com/photo-1519710164239-da123dc03ef4',
    title: 'Coffee table'
  }
];

const Profile = () => {
  const { profileUserName } = useParams();
  const [logUser, _setLogUser] = useLogginUser();

  const [profile, setProfile] = useState<User>();
  const [blocked, setBlocked] = useState<boolean>();
  const [follow, setFollow] = useState<boolean>();

  // const photo = useProfilePicture(profile?.photo);

  console.log(profileUserName);

  useEffect(() => {
    const getProfile = async () => {
      if (logUser?.jwt) {
        const config = {
          method: 'get' as Method,
          url: 'https://localhost:7298/api/User',
          params: {
            username: profileUserName
          },
          headers: {
            accept: 'text/plain',
            Authorization: `Bearer ${logUser.jwt}`
          }
        };

        const { data: response } = await axios(config);
        setProfile(response);
      }
    };
    getProfile();
  }, []);

  useEffect(() => {
    if (profileUserName && profile) {
      console.log(profile);
      logUser?.user.myBans?.forEach(ban => {
        console.log('ban');

        if (ban?.banned?.username === profileUserName) {
          setBlocked(true);
        }
      });
      logUser?.user.friendships?.forEach(friendship => {
        if (friendship?.friend?.username === profileUserName) {
          setFollow(true);
        }
      });
    }
  }, [profile]);

  const followHandler = async () => {
    if (logUser?.jwt) {
      const config = {
        method: 'post' as Method,
        url: 'https://localhost:7298/api/Friendship/addFriend',
        params: {
          user: profileUserName
        },
        headers: {
          accept: 'text/plain',
          Authorization: `Bearer ${logUser.jwt}`
        }
      };

      await axios(config);
      setFollow(true);
    }
  };

  const blockHandler = async () => {
    if (logUser?.jwt) {
      const config = {
        method: 'post' as Method,
        url: 'https://localhost:7298/api/Ban',
        params: {
          userToBan: profileUserName
        },
        headers: {
          accept: 'text/plain',
          Authorization: `Bearer ${logUser.jwt}`
        }
      };

      await axios(config);
      setBlocked(true);
    }
  };

  const birthdayToString = () => {
    if (profile?.birthdate) {
      const birth = new Date(profile?.birthdate);
      return `${birth.getDate()}.${birth.getMonth() + 1}.${birth.getFullYear()}`;
    }
    return '';
  };

  const genderToString = () => {
    if (profile?.gender !== null) {
      if (profile?.gender === 1) {
        return `Male`;
      } else if (profile?.gender === 0) {
        return `Female`;
      } else {
        return 'Other';
      }
    }
    return '';
  };
  return (
    <Grid container spacing={4}>
      <Grid item xs={12} sm={6} md={4}>
        <Card>
          <CardActions>
            {profileUserName ? (
              <>
                {!follow ? (
                  <Button size="small" onClick={followHandler}>
                    Follow
                  </Button>
                ) : (
                  ''
                )}
                {!blocked ? (
                  <Button size="small" onClick={blockHandler}>
                    Block
                  </Button>
                ) : (
                  ''
                )}
              </>
            ) : (
              ''
            )}
          </CardActions>
          <CardMedia
            component="img"
            src={`data:image/png;base64, ${profile?.photos?.[0].image}`}
            alt="random"
          />
          <CardContent>
            <Typography gutterBottom variant="h5" component="div">
              {profile ? `${profile?.name} ${profile?.surname}` : ''}
            </Typography>
            <Typography>BIRTH</Typography>
            <Typography sx={{ ml: 1, mb: 2 }} variant="body2" color="text.secondary">
              {profile ? birthdayToString() : ''}
            </Typography>
            <Typography>GENDER</Typography>
            <Typography sx={{ ml: 1, mb: 2 }} variant="body2" color="text.secondary">
              {profile ? genderToString() : ''}
            </Typography>
            <Typography>HEIGHT</Typography>
            <Typography sx={{ ml: 1, mb: 2 }} variant="body2" color="text.secondary">
              {profile ? `${profile?.height}` : ''}
            </Typography>
            <Typography>WEIGHT</Typography>
            <Typography sx={{ ml: 1, mb: 2 }} variant="body2" color="text.secondary">
              {profile ? `${profile?.weight}` : ''}
            </Typography>
          </CardContent>
        </Card>
      </Grid>

      <Grid item xs={12} sm={6} md={8}>
        <Typography gutterBottom variant="h3" component="div">
          Bio
        </Typography>
        <Typography>{profile?.bio}</Typography>
        <Typography gutterBottom variant="h3" component="div">
          Photo Feed
        </Typography>
        <ImageList variant="masonry" cols={3} gap={8}>
          {itemData.map(item => (
            <ImageListItem key={item.img}>
              <img
                src={`${item.img}?w=248&fit=crop&auto=format`}
                srcSet={`${item.img}?w=248&fit=crop&auto=format&dpr=2 2x`}
                alt={item.title}
                loading="lazy"
              />
            </ImageListItem>
          ))}
        </ImageList>
      </Grid>
    </Grid>
  );
};

export default Profile;
