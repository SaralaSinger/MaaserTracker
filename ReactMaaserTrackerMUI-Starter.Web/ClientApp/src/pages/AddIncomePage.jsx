import React, { useState, useEffect } from 'react';
import { Container, TextField, Button, Autocomplete, Typography } from '@mui/material';
import dayjs from 'dayjs';
import { useNavigate } from 'react-router-dom';
import axios from 'axios';


const AddIncomePage = () => {
    const [selectedDate, setSelectedDate] = useState(new Date());
    const [sources, setSources] = useState([]);
    const [amount, setAmount] = useState();
    const [selectedSource, setSelectedSource] = useState();

    const navigate = useNavigate();
    const onAddClick = async () => {
        await axios.post(`/api/maaser/addincome`, { sourceId: selectedSource, amount, date: selectedDate })
        navigate('/income')
    }

    const getSources = async () => {
        const { data } = await axios.get(`/api/maaser/getsources`);
        setSources(data);
    }

    useEffect(() => {
        getSources();
    }, [])

    return (
        <Container maxWidth="sm" sx={{ display: 'flex', flexDirection: 'column', justifyContent: 'center', height: '80vh' }}>
            <Typography variant="h2" component="h1" gutterBottom>
                Add Income
            </Typography>
            <Autocomplete
                options={sources}
                getOptionLabel={(option) => option.label}
                fullWidth
                onChange={(e, option) => setSelectedSource(option.id)}
                margin="normal"
                renderInput={(params) => <TextField {...params} label="Source" variant="outlined" />}
            />
            <TextField
                label="Amount"
                variant="outlined"
                type="number"
                InputProps={{ inputProps: { min: 0, step: 0.01 } }}
                fullWidth
                onChange={e => setAmount(e.target.value)}
                value={amount}
                margin="normal"
            />
            <TextField
                label="Date"
                type="date"
                value={dayjs(selectedDate).format('YYYY-MM-DD')}
                onChange={e => setSelectedDate(e.target.value)}
                renderInput={(params) => <TextField {...params} fullWidth margin="normal" variant="outlined" />}
            />
            <Button onClick={onAddClick} variant="contained" color="primary">Add Income</Button>
        </Container>
    );
}

export default AddIncomePage;
