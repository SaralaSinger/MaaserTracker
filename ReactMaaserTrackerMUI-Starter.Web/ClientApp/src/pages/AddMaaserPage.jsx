import React, { useState } from 'react';
import { Container, TextField, Button, Typography } from '@mui/material';
import dayjs from 'dayjs';
import { useNavigate } from 'react-router-dom';
import axios from 'axios';


const AddMaaserPage = () => {
    const [selectedDate, setSelectedDate] = useState(new Date());
    const [recipient, setRecipient] = useState('');
    const [amount, setAmount] = useState();

    const navigate = useNavigate();
    const onAddClick = async () => {
        await axios.post(`/api/maaser/addmaaser`, { recipient, amount, date: selectedDate })
        navigate('/maaser')
    }

    return (
        <Container maxWidth="sm" sx={{ display: 'flex', flexDirection: 'column', justifyContent: 'center', height: '80vh' }}>
            <Typography variant="h2" component="h1" gutterBottom>
                Add Maaser
            </Typography>
            <TextField label="Recipient" onChange={e => setRecipient(e.target.value)} value={recipient} variant="outlined" fullWidth margin="normal" />
            <TextField label="Amount" onChange={e => setAmount(e.target.value)} value={amount} variant="outlined" fullWidth margin="normal" />
            <TextField
                label="Date"
                type="date"
                value={dayjs(selectedDate).format('YYYY-MM-DD')}
                onChange={e => setSelectedDate(e.target.value)}
                renderInput={(params) => <TextField {...params} fullWidth margin="normal" variant="outlined" />}
            />
            <Button onClick={onAddClick} variant="contained" color="primary">Add Maaser</Button>
        </Container>
    );
}

export default AddMaaserPage;
