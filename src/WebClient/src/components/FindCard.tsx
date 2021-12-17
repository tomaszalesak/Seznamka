import { CardMedia, CardContent, Card, Typography, Grid, CardActionArea } from '@mui/material';
import { FC } from 'react';
import { useNavigate } from 'react-router-dom';

import useProfilePicture from '../hooks/useProfilePicture';
import { User } from '../utils/types';

// eslint-disable-next-line @typescript-eslint/no-unused-vars
const FindCard: FC<User> = ({ name, surname, username, bio, photo }) => {
  //const profilePhoto = useProfilePicture(photo);
  const profilePhoto = 'https://images.unsplash.com/photo-1549388604-817d15aa0110';
  const navigate = useNavigate();
  return (
    <Grid item xs={12} sm={6} md={4}>
      <Card>
        <CardActionArea onClick={() => navigate(`/profile/${username}`)}>
          <CardMedia component="img" image={profilePhoto} alt="random" />
          <CardContent>
            <Typography gutterBottom variant="h5" component="div">
              {`${name} ${surname}`}
            </Typography>
            <Typography variant="body2" color="text.secondary">
              {bio}
            </Typography>
          </CardContent>
        </CardActionArea>
      </Card>
    </Grid>
  );
};

export default FindCard;
