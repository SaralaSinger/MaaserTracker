import React, { useState, useEffect } from 'react';
import { Container, Typography, Box, Paper } from '@mui/material';
import axios from 'axios';

const OverviewPage = () => {

  const [overview, setOverview] = useState({});

  const getOverview = async () => {
    const { data } = await axios.get(`/api/maaser/getoverview`);
    setOverview(data);
  }

  useEffect(() => {
    getOverview();
  }, [])

  const { totalIncome, totalMaaser, totalObligation, totalStillObligated } = overview;

  return (
    <Container
      maxWidth="md"
      sx={{
        display: 'flex',
        flexDirection: 'column',
        justifyContent: 'center',
        alignItems: 'center',
        height: '80vh',
        textAlign: 'center'
      }}
    >
      <Paper elevation={3} sx={{ padding: '120px', borderRadius: '15px' }}>
        <Typography variant="h2" gutterBottom>
          Overview
        </Typography>
        <Box sx={{ marginBottom: '20px' }}>
          <Typography variant="h5" gutterBottom>
            Total Income: ${totalIncome}
          </Typography>
          <Typography variant="h5" gutterBottom>
            Total Maaser: ${totalMaaser}
          </Typography>
        </Box>
        <Box>
          <Typography variant="h5" gutterBottom>
            Maaser Obligated: ${totalObligation}
          </Typography>
          <Typography variant="h5" gutterBottom>
            Remaining Maaser obligation: ${totalStillObligated > 0 ? totalStillObligated : 0.00}
          </Typography>
        </Box>
      </Paper>
    </Container>
  );
}

export default OverviewPage;
